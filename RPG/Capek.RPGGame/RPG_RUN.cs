using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capek.RPGGame
{
    static class RPG_RUN
    {
        [STAThread]
        static void Main()
        {
            Engine.Engine.Instance.Run();
        }
    }
}
