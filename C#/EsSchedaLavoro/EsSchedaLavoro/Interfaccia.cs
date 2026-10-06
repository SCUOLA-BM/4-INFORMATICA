using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsSchedaLavoro
{
    public partial class Interfaccia : Component
    {
        public Interfaccia()
        {
            InitializeComponent();
        }

        public Interfaccia(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
