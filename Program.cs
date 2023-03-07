using System;
using System.Linq;
using System.Runtime.InteropServices;

using System.Threading;



namespace Numbers_for_ransom

{

    internal class Program

    {

        [DllImport("User32.Dll", EntryPoint = "PostMessageA")]
        
        private static extern bool PostMessage(IntPtr hWnd, uint msg, int wParam, int lParam);

        const int VK_RETURN = 0x0D;

        const int WM_KEYDOWN = 0x100;

        //The stuff up there is for the ENTER key simulation

        static private Timer timer = null;

        //This timer is used for a limit to how long a certain ReadLine can be active.

        private static string run = "  ";

        static void Main(string[] args)

        {
            //crow

            string[] crow = {
"                                                                                                        ",
"                                                                  ░░▒▒▒▒▓▓                              ",
"                                                            ░░▒▒▒▒▒▒▒▒▓▓░░                              ",
"                                                        ▓▓▒▒▒▒▒▒▓▓▒▒▓▓▓▓                                ",
"                                                      ▓▓▒▒▒▒▒▒▒▒▓▓▓▓██▓▓                                ",
"                                                  ░░▒▒▒▒▒▒▒▒▓▓▒▒▒▒▓▓██                                  ",
"                                                ▒▒▒▒▒▒▒▒▒▒▒▒▓▓▒▒▓▓████                                  ",
"                                            ░░▒▒▒▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓████                                  ",
"                                            ▒▒▒▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓██████                                  ",
"                                        ░░▒▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓██████                                  ",
"                                  ░░▒▒▒▒▒▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▓██████░░                                ",
"                              ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▓▓▒▒▓▓▓▓▓▓██████░░                              ",
"                          ▒▒▒▒▒▒▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▓▓▓▓██▓▓▓▓▓▓██▓▓▓▓              ░░              ",
"                          ▒▒▓▓▓▓▒▒▓▓▓▓▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓████▓▓░░            ░░              ",
"                            ░░▒▒▓▓▒▒▒▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▓▓▓▓▓▓▓▓▓▓▓░░          ░░              ",
"                                    ▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▓▓▓▓▒▒▓▓▓▓▓▓▓▓▓▓▓▓████░░      ░░░░              ",
"                                  ▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓████████                    ░░░░              ",
"                                ░░▒▒▓▓▒▒░░▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓██████                      ░░░░              ",
"                              ░░▓▓▓▓▒▒░░░░▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓██████░░                  ░░░░░░              ",
"                          ░░▒▒▓▓▒▒▒▒░░▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██████                    ░░░░                ",
"                          ▒▒▓▓▒▒░░▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██████▓▓                  ░░░░                  ",
"                        ░░▓▓▒▒░░▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓████████▓▓            ░░░░  ░░░░░░                ",
"                        ▒▒▒▒▓▓▓▓▓▓▒▒    ▒▒▓▓▓▓▓▓▓▓████████▓▓▓▓▓▓          ░░░░▒▒░░░░░░                  ",
"                        ▓▓▒▒▓▓▒▒      ░░▒▒██████████████▓▓▒▒▒▒▓▓▓▓        ░░░░░░░░░░                    ",
"                      ▒▒▓▓▓▓▒▒        ▒▒▓▓▓▓██████████▒▒▓▓▓▓▓▓▓▓▓▓▒▒    ░░░░▒▒▓▓░░░░                    ",
"                      ▒▒▓▓▒▒        ▒▒▓▓▒▒▓▓▓▓████▓▓▓▓▒▒▓▓▓▓▓▓▓▓▓▓▓▓  ░░░░░░▓▓  ░░                      ",
"                      ▓▓▓▓    ░░░░▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░░░░░▒▒    ░░                      ",
"                      ▓▓░░  ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒░░                            ",
"                    ▒▒▒▒  ▒▒▓▓▓▓▓▓▓▓▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░░░▒▒▓▓░░                            ",
"                    ▒▒  ▒▒▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░░░░░▓▓▓▓▒▒░░                          ",
"                        ▓▓▓▓▓▓▓▓▓▓▓▓░░▒▒▓▓▓▓▓▓▓▓▓▓░░▓▓▓▓▓▓▓▓▓▓▓▓░░░░▒▒▓▓▓▓▓▓░░                          ",
"                        ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░░░▒▒▓▓▓▓▓▓▓▓▒▒                          ",
"                       ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░░░▒▒▓▓▓▓▓▓▓▓▓▓░░                         ",
"                      ░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▒▒                        ",
"                      ▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓                        ",
"                      ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓                        ",
"                    ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▓▓▓▓▓▓▓▓▓▒▒░░▒▒▓▓██████▓▓▓▓▓▓▓▓▓▓▓▓▒▒                      ",
"                  ░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒░░▒▒▓▓▒▒▒▒▒▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▒▒                      ",
"                ░░▓▓▓▓██▓▓▓▓▒▒▒▒▒▒▒▒▒▒▓▓▒▒▒▒▒▒▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▒▒▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓░░                    ",
"              ░░▓▓████▒▒▓▓▓▓▓▓▒▒▒▒▒▒▒▒▒▒▓▓▒▒▒▒▓▓▓▓▒▒▒▒▒▒▒▒▓▓▓▓▒▒▓▓▓▓████▓▓▓▓▓▓▓▓▓▓▒▒                    ",
"              ▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▒▒▒▒▓▓▒▒▓▓▓▓▒▒▒▒▓▓▓▓▒▒▒▒▓▓▓▓▒▒▓▓▓▓▓▓▒▒▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒░░                  ",
"              ░░▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒                  ",
"            ▒▒▒▒▓▓▒▒▓▓██▓▓████▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒              ",
"            ░░▓▓▒▒▓▓▓▓██▓▓▓▓██▓▓▓▓▓▓▓▓▒▒▒▒▒▒░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▓████████▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒          ",
"            ▒▒▒▒▒▒▓▓▓▓██▒▒▓▓████▓▓▓▓▓▓▓▓▓▓▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓████▓▓▓▓▓▓▓▓████████▓▓██▓▓▓▓▓▓▓▓▓▓▓▓          ",
"            ▓▓  ▒▒▓▓██▓▓▓▓▓▓██▓▓▒▒▓▓▓▓▒▒▓▓▒▒▒▒▓▓▓▓▓▓▒▒▒▒▓▓██▓▓▓▓▓▓▓▓▒▒▓▓██████▓▓▓▓▓▓██▓▓██▓▓▓▓▓▓░░      ",
"            ▒▒▒▒▓▓██▓▓▒▒▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓████▓▓▓▓▓▓▓▓██████▓▓▒▒▓▓▓▓▓▓████████░░      ",
"          ░░▓▓▓▓▓▓▓▓▒▒▓▓▓▓████▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓████▓▓▓▓██████████▓▓▒▒▒▒▓▓▓▓▓▓▓▓████▓▓      ",
"      ██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▓▓██▒▒██▓▓▓▓▓▓▒▒▒▒▒▒▒▒▓▓▓▓██████░░    ",
"            ██▓▓▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▒▒██████▓▓▓▓▒▒▒▒▒▒▒▒▓▓▓▓████▓▓    ",
"        ░░██▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓████▓▓▒▒▓▓██▓▓▓▓████▓▓▓▓▓▓▒▒▓▓▓▓▓▓██    ",
"        ▓▓████▓▓▓▓▓▓████▓▓▓▓▓▓▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▓██▓▓▓▓████▓▓▓▓▒▒▒▒▓▓▓▓▒▒▓▓▒▒  ",
"      ▒▒▓▓██▓▓▓▓▓▓██▓▓▓▓██▒▒▓▓▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▓▓▓▒▒▓▓██▓▓▓▓████▓▓▒▒▒▒▒▒▓▓▓▓▓▓▒▒▒▒  ",
"    ▒▒▓▓████▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▓▒▒▓▓▓▓▓▓▓▓██▓▓▒▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▒▒  ",
"    ▒▒▓▓▓▓██▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▓▒▒▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓░░  ",
"  ▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▓▓▓▓▓▓▓▒▒  ",
"  ░░▓▓▓▓▓▓▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▒▒▓▓██▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓  ",
"    ▓▓▓▓▓▓▒▒▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▓██▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓  ",
"    ▓▓▓▓▓▓▒▒▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓████▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒░░▒▒▓▓▓▓▓▓████▓▓▓▓██▓▓  ▓▓▒▒",
"    ▒▒▓▓▓▓▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██████▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓████▓▓░░░░░░▒▒▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓  ░░▒▒",
"  ░░▒▒▓▓▓▓▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██████▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██░░░░░░░░▓▓████▓▓▓▓▓▓██▓▓▓▓▒▒    ▓▓",
"  ▒▒▒▒▒▒▓▓▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██████▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░░░▒▒▒▒▓▓▓▓████▓▓▓▓▓▓██▓▓▓▓▒▒░░    ",
"  ░░▒▒▓▓██▒▒▓▓████▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓████▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░░░░░▒▒▒▒▓▓██▓▓▓▓██▓▓▓▓████▓▓▓▓▒▒▒▒    ",
"    ▒▒▓▓██▒▒▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒░░░░░░▒▒▓▓▓▓▓▓██▓▓▓▓██▓▓▓▓▓▓▓▓██▓▓▓▓▒▒    ",
"    ▒▒████▓▓▓▓██▓▓▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▓██▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓░░░░░░░░▓▓▓▓▓▓▓▓▓▓▒▒▓▓▓▓▓▓██▓▓██▓▓▓▓██▓▓▒▒▒▒  ",
"    ▓▓████▓▓████▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▓██▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓░░░░░░░░▓▓▓▓▓▓▓▓▒▒░░▒▒▓▓▓▓██████▓▓██▓▓▓▓▓▓░░  ",
"    ▓▓██▓▓██▒▒░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▓▓██▓▓▓▓████▓▓▓▓▓▓▓▓▓▓░░░░░░▒▒▓▓▓▓▓▓▓▓  ░░▒▒▓▓▓▓▓▓██▓▓████░░▓▓▓▓▒▒  ",
"  ▒▒██▓▓▓▓▓▓  ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒████▓▓▓▓████▓▓▓▓▓▓▓▓▒▒░░░░▓▓▓▓▓▓▓▓▓▓▓▓░░░░▒▒▓▓▓▓▓▓██▓▓████  ▒▒▓▓▒▒  ",
"  ▒▒██▓▓▓▓░░░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓░░▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓░░  ▒▒▓▓▓▓▓▓▓▓▓▓████    ▒▒▒▒  ",
"  ▒▒████    ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓░░░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓  ▒▒▓▓▓▓██▓▓  ████    ░░▒▒  ",
"  ▒▒██▓▓  ░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░░░▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░░░▒▒▓▓██▓▓  ░░██    ▒▒░░  ",
"    ▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒▒▒▒▒▒██▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓    ▒▒▓▓██▓▓    ██          ",
"      ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒▒▒▒▒▒██▓▓██▓▓▓▓▓▓▒▒░░░░▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░  ░░▓▓██▓▓    ▒▒░░        ",
"        ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒▒▒▒▓▓██▓▓▒▒░░░░██▒▒░░▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒    ▓▓▓▓▓▓      ██░░      ",
"      ░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓████▓▓▒▒▒▒          ░░░░░░░░▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░  ▓▓▓▓██      ░░▒▒      ",
"      ░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓████                        ▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒      ▓▓▒▒              ",
"      ▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓████                        ▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓        ▓▓░░            ",
"      ░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓████                          ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓          ▒▒░░          ",
"        ▒▒▓▓▓▓▓▓▓▓▓▓▓▓████▓▓                          ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░                        ",
"          ▒▒▓▓▓▓▓▓▓▓██▓▓██                            ██░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░░░                          ",
"              ░░▓▓▓▓██▓▓██                            ▓▓░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓                                ",
"                ▓▓▓▓▓▓████                            ░░  ██▓▓▓▓▓▓██░░                                  ",
"                ▓▓██████▒▒                                ▒▒████████░░                                  ",
"              ░░▓▓██████░░                                ░░▓▓██████▒▒                                  ",
"              ▓▓▓▓██████                                    ▓▓▓▓██▓▓██                                  ",
"            ▒▒▓▓████████                                    ▒▒▓▓██████                                  ",
"          ░░▓▓▓▓▓▓██████                                      ▓▓██████▓▓                                ",
"        ░░▓▓▓▓▓▓████████                                      ▓▓▓▓▓▓████                                ",
"    ░░▒▒████████████████                                      ▓▓▓▓██▓▓▓▓                                ",
"                                                            ▓▓▓▓██████▓▓░░                              ",
};

            //p1

            for (int i = 0; crow.Length > i; i++)
            {
                Console.WriteLine(crow[i]);
            }

            int num1, num2, chosenNum;
            num1 = 11;
            num2 = 101;
            chosenNum = -1;

            //matryoshka code.  used for receiving the numbers input from the user within the bounds of my ideals.

            Console.WriteLine("Salutations, ye that hails from the tomb of revival.  I am crow.  I haven't seen one of your kind in many, many years.  Allow us to have a contest.  Please bestow upon me an integer greater than 0 and less than 10, and an integer greater than 10 and less than 20.");
            Console.WriteLine("");

            while (num1 > 10 || num1 <= 0)
            {
                Console.Write("Integer 1: ");
                num1 = Convert.ToInt32(Console.ReadLine());
                if (num1 <= 10 && num1 > 0)
                {
                    while (num2 > 20 || num2 <= 10)
                    {
                        Console.Write("Integer 2: ");
                        num2 = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < 5; i++)
                        {
                            while (num2 == (num1 + i))
                            {
                                Console.WriteLine("The second integer must be greater than the first integer by 5.");
                                Console.Write("Integer 2: ");
                                num2 = Convert.ToInt32(Console.ReadLine());
                            }
                        }

                        if (num2 <= 20 && num2 > 9)
                        {
                            Console.WriteLine("Lastly, write down an integer between the two that you have already chosen.");
                            while (chosenNum > num2 || chosenNum <= num1)
                            {
                                Console.Write("Integer 3: ");
                                chosenNum = Convert.ToInt32(Console.ReadLine());
                                if (chosenNum <= num2 && chosenNum >= num1)
                                    break;
                                else;
                            }
                            break;
                        }
                        else;
                    }
                    break;
                }
                else;
            }

            Console.Write("Now, I will guess five random numbers between " + num1 + " and " + num2 + ".  If I guess the correct number, I get to feast on your body, deal?  Now then, let's see... ");

            //generation of the random numbers

            Random generator = new Random();
            int[] guess = { 0, 0, 0, 0, 0 };
            bool unique = false, guessed = false;
            int randNum = 0;

            for (int i = 0; guess.Length > i; i++)
            {
                while (!unique)
                {
                    randNum = generator.Next(num1, num2 + 1);
                    if (!guess.Contains(randNum))
                        unique = true;
                }
                guess[i] = randNum;
                unique = false;

                if ((guess.Length - 1) == i)
                {
                    Console.WriteLine(guess[i] + ".");
                }
                else
                {
                    Console.Write(guess[i] + ", ");
                }

                if (guess[i] == chosenNum)
                    guessed = true;
            }

            //dies?
            if (guessed == true)
            {
                Console.WriteLine("I eat you now. om nom");
                Thread.Sleep(5000);
                Environment.Exit(0); //closes program if number was guessed
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Alright, I think both you and I can agree that that game was rigged against me.  I propose a better game: You role two dice, and then if I roll the same number, I eat you!");
                Console.WriteLine("");
                bool properAns = false;
                int j = 1;

                while (!properAns)
                {
                    Console.Write("Roll the dice? Y/N: ");
                    string answer = Console.ReadLine();
                    int verifY = answer.ToLower().IndexOf("y"), verifN = answer.ToLower().IndexOf("n"); //this ensures that as long as the first letter typed is either y/n, the program moves on.  makes my job easier.

                    if (verifY == 0)
                    {
                        Console.WriteLine("Alright, great!  Let's see what you got...");
                        properAns = true;
                    }
                    else if (verifN == 0)
                    {
                        j = j + 1;
                        Thread.Sleep(5000 * j);
                        Console.WriteLine("Whoa, looks like you passed out for a little bit there!  I almost lost control of myself and ate you...  I think it's in your best interest to roll the dice.");
                    }
                    else
                    {
                        Console.WriteLine("That is not a valid answer.");
                    }
                }

                int die1 = generator.Next(1, 7), die2 = generator.Next(1, 7), die3 = generator.Next(1, 7), die4 = generator.Next(1, 7);
                for (int i = 0; i < 3; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }
                Console.WriteLine("You rolled a " + (die1 + die2) + "!  Now, let's see my roll...");
                for (int i = 0; i < 3; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }
                Console.WriteLine("I rolled a " + (die3 + die4) + "!");

                //I like the thread.sleeps, as they make it so that all of my text does not generate at the same time.  Gives the impression that they are actually taking the time to roll the dice, albeit perhaps a bit fast.

                if ((die1 + die2) == (die3 + die4))
                {
                    Console.WriteLine("I eat you now. om nom");
                    Thread.Sleep(5000);
                    Environment.Exit(0);
                }
                else
                {
                    for (int i = 1; i < 3; i++)
                    {
                        if (i == 1)
                            Console.WriteLine("Okay, just two more tries!");
                        else
                            Console.WriteLine("Okay, just one more try!");

                        die3 = generator.Next(1, 7);
                        die4 = generator.Next(1, 7);
                        for (int k = 0; k < 3; k++)
                        {
                            Console.Write(". ");
                            Thread.Sleep(500);
                        }
                        Console.WriteLine("I rolled a " + (die3 + die4) + "!");
                        if (die1 + die2 == die3 + die4)
                        {
                            Console.WriteLine("I eat you now. om nom");
                            Thread.Sleep(5000);
                            Environment.Exit(0);
                        }
                    }
                }

                Console.WriteLine("Wow!  I totally failed all three times!  I propose one last game..!");

                //p3

                Console.WriteLine();
                Console.WriteLine("I am going to chase you, and if you can outrun me, I'll concede and you can be free.");
                Console.WriteLine("[Press the spacebar as fast as possible in the next five seconds to escape.]");
                for (int k = 3; k > 0; k--)
                {
                    Console.WriteLine(k);
                    Thread.Sleep(1000);
                }
                Console.WriteLine("Start!");
                Console.WriteLine("");

                Program.timer = new Timer(TimerCallback, null, 5000, Timeout.Infinite); //This starts the timer

                run = Console.ReadLine();

                char toFind = ' ';

                int count = 0; int n = 0; int foof = 3;
                if (run.IndexOf(toFind, n) != 0)
                {
                    Console.WriteLine("You miserably failed!  I eat you now.  om nom");
                    Thread.Sleep(5000);
                    Environment.Exit(0);
                }
                else
                {
                    for (int i = 0; i < run.Length; i++)
                    {
                        if (run[i] == ' ') count++; //Verifying for occurences of the space
                    }
                }

                Console.WriteLine("You ran " + count + " kilometres!");

                double[] crowFlyDec = { 0, 0, 0 }; double totalDistanceDec = 0;
                int[] crowFlyInt = { 0, 0, 0 }; int totalDistanceInt = 0;
                for (int i = 0; i < 3; i++)
                {
                    crowFlyDec[i] = generator.NextDouble();
                    crowFlyInt[i] = generator.Next(num1, num2);
                    if (i == 0)
                    {
                        Console.Write("The crow flew " + (crowFlyInt[0] + Math.Round(crowFlyDec[i], chosenNum)) + " kilometres... ");
                        Thread.Sleep(1000);
                    }
                    else if (i == 1)
                    {
                        Console.Write("another " + (crowFlyInt[1] + Math.Round(crowFlyDec[i], chosenNum)) + " kilometres... ");
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        Console.Write("another " + (crowFlyInt[2] + Math.Round(crowFlyDec[i], chosenNum)) + " kilometres... ");
                        Thread.Sleep(1000);
                        totalDistanceDec = crowFlyDec[0] + crowFlyDec[1] + crowFlyDec[2];
                        totalDistanceInt = crowFlyInt[0] + crowFlyInt[1] + crowFlyInt[2];
                        Console.Write(totalDistanceInt + Math.Round(totalDistanceDec, chosenNum) + " total kilometres!");
                        Thread.Sleep(1000);
                    }
                }
                double crowFlew = totalDistanceDec + totalDistanceInt;

                Console.WriteLine("");
                Console.WriteLine("");

                if (crowFlew >= count)
                {
                    Console.WriteLine("I eat you now.  om nom");
                    Thread.Sleep(5000);
                    Environment.Exit(0);
                }
                else
                    Console.WriteLine("[You successfully escaped the crow!]");

                Thread.Sleep(10000);


            }

            }

        private static void TimerCallback(Object o)

        {

            //When this is called, it forcefully stops the ReadLine by simulating an ENTER key press. 
            Console.WriteLine("Time's up!");



            IntPtr hWnd = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;

            PostMessage(hWnd, WM_KEYDOWN, VK_RETURN, 0);

        }

    }

}

