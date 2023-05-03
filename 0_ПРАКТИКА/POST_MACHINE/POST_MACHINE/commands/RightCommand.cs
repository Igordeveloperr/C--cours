﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POST_MACHINE.commands
{
    internal class RightCommand : ICommand
    {
        public readonly static string Pattern = "r";
        public void Execute(ref int increment, ref int index, ref string[] commands, ref List<Button> cells)
        {
            var arr = commands[increment - 1].Split(" ");
            index++;
            increment = Convert.ToInt32(arr[1]);
            increment -= 1;
        }
    }
}
