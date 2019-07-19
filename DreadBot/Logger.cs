//MIT License
//Copyright(c) [2019]
//[Xylex Sirrush Rayne]
//
//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:
//
//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.
//
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace DreadBot
{
    //Every Logable event is set here. Depending on the set log level, it is Printed to the console and Writen to local logs.
    public class Logger
    {
        public static LogLevel CurrentLogLevel = LogLevel.Off;
        public static LogLevel CurrentConsoleLevel = LogLevel.Debug;
        private static void Log(string text, LogLevel level = LogLevel.Debug)
        {
            Console.ForegroundColor = ConsoleColor.White;
            switch (level)
            {
                case LogLevel.Fatal: { Console.ForegroundColor = ConsoleColor.Red; break; }
                case LogLevel.Error: { Console.ForegroundColor = ConsoleColor.Red; break; }
                case LogLevel.Warn: { Console.ForegroundColor = ConsoleColor.Yellow; break; }
                case LogLevel.Admin: { Console.ForegroundColor = ConsoleColor.DarkCyan; break; }
            }

            if (CurrentLogLevel >= level) { System.IO.File.AppendAllText(@"log.txt", "[" + level + "] " + text); }
            if (CurrentConsoleLevel >= level) { Console.WriteLine("[" + level + "] " + text); }
            Console.ResetColor();
        }

        public static void LogDebug(string text) { Log(text, LogLevel.Debug); }
        public static void LogAdmin(string text) { Log(text, LogLevel.Admin); }
        public static void LogInfo(string text) { Log(text, LogLevel.Info); }
        public static void LogWarn(string text) { Log(text, LogLevel.Warn); }
        public static void LogError(string text) { Log(text, LogLevel.Error); }
        public static void LogFatal(string text) { Log(text, LogLevel.Fatal); }
    }

    public enum LogLevel : byte
    {
        Debug = 6,
        Admin = 5,
        Info = 4,
        Warn = 3,
        Error = 2,
        Fatal = 1,
        Off = 0
    }



}
