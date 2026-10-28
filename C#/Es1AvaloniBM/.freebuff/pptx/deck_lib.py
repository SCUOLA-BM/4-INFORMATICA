"""Helper di impaginazione per il deck "Laboratorio XAML"."""

import re

from PIL import ImageFont
from pptx import Presentation
from pptx.dml.color import RGBColor
from pptx.enum.shapes import MSO_SHAPE
from pptx.enum.text import MSO_ANCHOR, MSO_AUTO_SIZE, PP_ALIGN
from pptx.oxml import parse_xml
from pptx.oxml.ns import nsdecls, qn
from pptx.util import Inches, Pt

# --------------------------------------------------------------------------
# Palette e costanti (le stesse dell'app)
# --------------------------------------------------------------------------
SW, SH = 13.333, 7.5

BG = "0E1015"
SURFACE = "171A21"
SURFACE2 = "12151C"
LINE = "2A3040"
TEXT = "F2F4FA"
BODY = "A9B2C3"
MUTED = "8A93A5"
ACCENT = "8B7CFF"
MINT = "4CD7B0"
AMBER = "F5B54B"
BLUE = "6FA8FF"
CODE = "D5DBE7"

FONT = "Segoe UI"
MONO = "Consolas"

FONT_FILES = {
    ("Segoe UI", False): r"C:\Windows\Fonts\segoeui.ttf",
    ("Segoe UI", True): r"C:\Windows\Fonts\segoeuib.ttf",
    ("Consolas", False): r"C:\Windows\Fonts\consola.ttf",
    ("Consolas", True): r"C:\Windows\Fonts\consolab.ttf",
}

WARNINGS = []


def C(value):
    return RGBColor.from_string(value.lstrip("#").upper())


# --------------------------------------------------------------------------
# Slide e forme
# --------------------------------------------------------------------------
def new_deck():
    prs = Presentation()
    prs.slide_width = Inches(SW)
    prs.slide_height = Inches(SH)
    return prs


def blank(prs):
    slide = prs.slides.add_slide(prs.slide_layouts[6])
    fill = slide.background.fill
    fill.solid()
    fill.fore_color.rgb = C(BG)
    return slide


def rect(slide, x, y, w, h, fill=None, line=None, radius=0.0, line_w=1.0):
    shape = slide.shapes.add_shape(
        MSO_SHAPE.ROUNDED_RECTANGLE if radius else MSO_SHAPE.RECTANGLE,
        Inches(x), Inches(y), Inches(w), Inches(h),
    )
    shape.shadow.inherit = False
    if fill:
        shape.fill.solid()
        shape.fill.fore_color.rgb = C(fill)
    else:
        shape.fill.background()
    if line:
        shape.line.color.rgb = C(line)
        shape.line.width = Pt(line_w)
    else:
        shape.line.fill.background()
    if radius:
        shape.adjustments[0] = min(0.5, radius / max(0.01, min(w, h)))
    return shape


def hline(slide, x, y, w, color=LINE, thickness=1.0):
    return rect(slide, x, y, w, 0.012, fill=color, line_w=thickness)


def arrow(slide, x, y, w, h, color="313848"):
    shape = slide.shapes.add_shape(MSO_SHAPE.RIGHT_ARROW, Inches(x), Inches(y),
                                   Inches(w), Inches(h))
    shape.shadow.inherit = False
    shape.fill.solid()
    shape.fill.fore_color.rgb = C(color)
    shape.line.fill.background()
    return shape


def _font_file(name, bold):
    return FONT_FILES.get((name, bold), r"C:\Windows\Fonts\segoeui.ttf")


def _measure_font(name, bold, size):
    return ImageFont.truetype(_font_file(name, bold), max(1, int(round(size * 4))))


def text_width(value, size, bold=False, font=FONT):
    value = value.replace("**", "")
    return _measure_font(font, bold, size).getlength(value) / 4.0


def _wrap_count(value, size, bold, font, width_pt):
    value = value.replace("**", "")
    fnt = _measure_font(font, bold, size)
    lines = 0
    for chunk in value.split("\n"):
        words = chunk.split(" ")
        current = ""
        n = 1
        for word in words:
            probe = word if not current else current + " " + word
            if fnt.getlength(probe) / 4.0 <= width_pt or not current:
                current = probe
            else:
                n += 1
                current = word
        lines += n
    return lines


# --------------------------------------------------------------------------
# Testo
# --------------------------------------------------------------------------
def _style_run(run, size, color, bold, italic, font):
    f = run.font
    f.size = Pt(size)
    f.name = font
    f.bold = bold
    f.italic = italic
    f.color.rgb = C(color)


def _add_runs(paragraph, value, size, color, bold, font, highlight=None):
    """Aggiunge il testo; **grassetto** diventa un run evidenziato."""
    parts = value.split("**")
    for i, part in enumerate(parts):
        if not part:
            continue
        run = paragraph.add_run()
        run.text = part
        is_bold = bold or (i % 2 == 1)
        run_color = color if i % 2 == 0 else (highlight or TEXT)
        _style_run(run, size, run_color, is_bold, False, font)


def text(slide, x, y, w, h, value, size=12, color=BODY, bold=False,
         font=FONT, align=PP_ALIGN.LEFT, anchor=MSO_ANCHOR.TOP,
         line_spacing=None, space_after=0, spc=None, margins=0.0,
         highlight=None):
    box = slide.shapes.add_textbox(Inches(x), Inches(y), Inches(w), Inches(h))
    tf = box.text_frame
    tf.word_wrap = True
    tf.auto_size = MSO_AUTO_SIZE.NONE
    tf.vertical_anchor = anchor
    tf.margin_left = Inches(margins)
    tf.margin_right = Inches(margins)
    tf.margin_top = Inches(margins)
    tf.margin_bottom = Inches(margins)

    for i, line in enumerate(str(value).split("\n")):
        p = tf.paragraphs[0] if i == 0 else tf.add_paragraph()
        p.alignment = align
        if line_spacing:
            p.line_spacing = line_spacing
        if space_after:
            p.space_after = Pt(space_after)
        _add_runs(p, line, size, color, bold, font, highlight)
        if spc:
            for run in p.runs:
                run.font._rPr.set("spc", str(spc))

    needed = _wrap_count(value, size, bold, font, (w - 2 * margins) * 72)
    need_h = needed * size * 1.22 * (line_spacing or 1.0) / 72.0
    if need_h > h + 0.02:
        WARNINGS.append(f"TESTO oltre il box: {value[:34]!r} serve {need_h:.2f}\" in {h:.2f}\"")
    return box


def bullets(slide, x, y, w, h, items, size=12.5, color=BODY,
            bullet_color=ACCENT, line_spacing=1.16, gap=8, anchor=MSO_ANCHOR.TOP):
    box = slide.shapes.add_textbox(Inches(x), Inches(y), Inches(w), Inches(h))
    tf = box.text_frame
    tf.word_wrap = True
    tf.auto_size = MSO_AUTO_SIZE.NONE
    tf.vertical_anchor = anchor
    tf.margin_left = 0
    tf.margin_right = 0
    tf.margin_top = 0
    tf.margin_bottom = 0

    indent = 0.24
    for i, item in enumerate(items):
        p = tf.paragraphs[0] if i == 0 else tf.add_paragraph()
        p.line_spacing = line_spacing
        p.space_after = Pt(gap)
        pPr = p._p.get_or_add_pPr()
        pPr.set("marL", str(int(Inches(indent))))
        pPr.set("indent", str(-int(Inches(indent))))
        pPr.append(parse_xml(
            f'<a:buClr {nsdecls("a")}><a:srgbClr val="{bullet_color}"/></a:buClr>'))
        pPr.append(parse_xml(
            f'<a:buFont {nsdecls("a")} typeface="Segoe UI Symbol"/>'))
        pPr.append(parse_xml(
            f'<a:buChar {nsdecls("a")} char="\u25b8"/>'))
        _add_runs(p, item, size, color, False, FONT, highlight=TEXT)

    needed = sum(
        _wrap_count(it, size, False, FONT, (w - indent) * 72) for it in items
    )
    need_h = (needed * size * 1.22 * line_spacing + gap * max(0, len(items) - 1)) / 72.0
    if need_h > h + 0.02:
        WARNINGS.append(f"BULLET oltre il box: {items[0][:30]!r} serve {need_h:.2f}\" in {h:.2f}\"")
    return box


# --------------------------------------------------------------------------
# Evidenziazione del codice
# --------------------------------------------------------------------------
XAML_RE = re.compile(
    r'(?P<comment><!--.*?-->)'
    r'|(?P<tag></?[A-Za-z_][\w:.]*)'
    r'|(?P<attr>[A-Za-z_][\w:.]*(?=\s*=))'
    r'|(?P<str>"[^"]*")'
)
CS_RE = re.compile(
    r'(?P<comment>//.*$)'
    r'|(?P<attr>\[[A-Za-z_][\w.]*)'
    r'|(?P<str>"[^"]*")'
    r'|(?P<kw>\b(?:using|namespace|public|private|internal|partial|class'
    r'|record|new|void|return|if|else|null|true|false|string|int|double'
    r'|bool|var|get|set|static|readonly|async|await)\b)'
    r'|(?P<num>\b\d+\b)'
)

XAML_COLORS = {
    "comment": MUTED,
    "tag": ACCENT,
    "attr": MINT,
    "str": AMBER,
}
CS_COLORS = {
    "comment": MUTED,
    "attr": AMBER,
    "str": AMBER,
    "kw": ACCENT,
    "num": MINT,
}


def _highlight_line(paragraph, line, size, lang, accent):
    pattern = XAML_RE if lang == "xaml" else CS_RE
    colors = XAML_COLORS if lang == "xaml" else CS_COLORS
    if lang == "xaml":
        colors = dict(colors, tag=accent or ACCENT)
    pos = 0
    for match in pattern.finditer(line):
        if match.start() > pos:
            run = paragraph.add_run()
            run.text = line[pos:match.start()]
            _style_run(run, size, CODE, False, False, MONO)
        kind = match.lastgroup
        run = paragraph.add_run()
        run.text = match.group(0)
        _style_run(run, size, colors.get(kind, CODE), kind in ("kw", "tag"), False, MONO)
        pos = match.end()
    if pos < len(line):
        run = paragraph.add_run()
        run.text = line[pos:]
        _style_run(run, size, CODE, False, False, MONO)


def code_panel(slide, x, y, w, h, code, lang="xaml", accent=ACCENT,
               label=None, max_size=12.5, min_size=9.4):
    rect(slide, x, y, w, h, fill=SURFACE2, line=LINE, radius=0.10)
    rect(slide, x + 0.24, y + 0.23, 0.075, 0.075, fill=accent, radius=0.038)
    label = label or ("XAML" if lang == "xaml" else "C#")
    text(slide, x + 0.40, y + 0.155, 2.4, 0.24, label, 8.6, MUTED, bold=True, spc=120)

    lines = code.strip("\n").rstrip().split("\n")
    longest = max((len(line) for line in lines), default=1)
    avail_w = (w - 0.52) * 72
    size = min(max_size, avail_w / max(1, longest * 0.552))
    avail_h = (h - 0.62) * 72
    if len(lines) * size * 1.19 > avail_h:
        size = avail_h / (len(lines) * 1.19)
    if size < min_size:
        WARNINGS.append(f"CODICE troppo denso: {longest} caratteri, {len(lines)} righe")
        size = min_size
    if longest * 0.552 * size > avail_w + 1:
        WARNINGS.append(f"CODICE troppo largo: {longest} caratteri a {size:.1f}pt")

    box = slide.shapes.add_textbox(
        Inches(x + 0.26), Inches(y + 0.50), Inches(w - 0.46), Inches(h - 0.60))
    tf = box.text_frame
    tf.word_wrap = False
    tf.auto_size = MSO_AUTO_SIZE.NONE
    tf.margin_left = 0
    tf.margin_right = 0
    tf.margin_top = 0
    tf.margin_bottom = 0
    for i, line in enumerate(lines):
        p = tf.paragraphs[0] if i == 0 else tf.add_paragraph()
        p.line_spacing = 1.0
        p.space_after = 0
        p.space_before = 0
        if line:
            _highlight_line(p, line, size, lang, accent)
        else:
            run = p.add_run()
            run.text = " "
            _style_run(run, size, CODE, False, False, MONO)
    return box


def shell_panel(slide, x, y, w, h, lines, accent=MINT):
    rect(slide, x, y, w, h, fill=SURFACE2, line=LINE, radius=0.10)
    for i in range(3):
        rect(slide, x + 0.24 + i * 0.20, y + 0.22, 0.08, 0.08,
             fill=["#3A4152", "#333B4A", "#2C3341"][i], radius=0.04)
    text(slide, x + 1.05, y + 0.14, 2.0, 0.22, "PowerShell", 8.6, MUTED, bold=True)

    box = slide.shapes.add_textbox(
        Inches(x + 0.28), Inches(y + 0.55), Inches(w - 0.5), Inches(h - 0.65))
    tf = box.text_frame
    tf.word_wrap = False
    tf.auto_size = MSO_AUTO_SIZE.NONE
    tf.margin_left = 0
    tf.margin_right = 0
    tf.margin_top = 0
    tf.margin_bottom = 0
    size = 11.2
    for i, line in enumerate(lines):
        p = tf.paragraphs[0] if i == 0 else tf.add_paragraph()
        p.line_spacing = 1.35
        p.space_after = 0
        if line.startswith("$ "):
            run = p.add_run()
            run.text = "$ "
            _style_run(run, size, accent, True, False, MONO)
            run = p.add_run()
            run.text = line[2:]
            _style_run(run, size, TEXT, False, False, MONO)
        else:
            color = MINT if ("0 Error" in line or "Build succeeded" in line) else MUTED
            run = p.add_run()
            run.text = line
            _style_run(run, size, color, False, False, MONO)


# --------------------------------------------------------------------------
# Elementi comuni delle slide
# --------------------------------------------------------------------------
def chrome(slide, kicker, title, subtitle, color, page=None, total=None):
    rect(slide, 0, 0, SW, 0.055, fill=color)
    text(slide, 0.7, 0.36, 9.6, 0.24, kicker.upper(), 9.2, color, bold=True, spc=140)
    if page:
        text(slide, 10.9, 0.36, 1.7, 0.24, f"{page:02d} / {total}", 8.6,
             MUTED, align=PP_ALIGN.RIGHT)

    length = len(title)
    if length <= 19:
        size = 34
    elif length <= 30:
        size = 31
    elif length <= 40:
        size = 26.5
    else:
        size = 22.5
    if text_width(title, size, True) > 11.9 * 72:
        size = 20.5
    text(slide, 0.7, 0.63, 12.0, 0.78, title, size, TEXT, bold=True)
    if subtitle:
        text(slide, 0.7, 1.36, 11.9, 0.42, subtitle, 13.5, BODY)


def footer(slide, page, total):
    hline(slide, 0.7, 7.08, 11.93, color="222834")
    text(slide, 0.7, 7.16, 8.0, 0.22, "Laboratorio XAML · esercizio unico", 8.4, MUTED)
    text(slide, 10.6, 7.16, 2.0, 0.22, f"{page:02d} / {total}", 8.4,
         MUTED, align=PP_ALIGN.RIGHT)


def note_slide(slide, value):
    slide.notes_slide.notes_text_frame.text = value
