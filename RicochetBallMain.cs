// Author: Anthony Sam
// Program Name: Ricochet Ball

// Name of this file: RicochetBallMain.cs
// Purpose of this file: Launch the window showing the form where the bouncing ball will be displayed.
// Purpose of this entire program: This program shows a ball bouncing on the walls.

// Source files in this program: RicochetBallForm.cs, RicochetBallMain.cs
//The source files in this program should be compiled in the order specified below in order to satisfy dependencies.
//  1. RicochetBallForm.cs compiles into library file RicochetBallForm.dll
//  2. RicochetBallMain.cs compiles and links with the dll file above to create RicochetBall.exe
//Compile (and link) this file:
//mcs -r:System.Windows.Forms.dll -r:RicochetBallForm.dll -out:RicochetBall.exe RicochetBallMain.cs
//Execute (Linux shell): ./RicochetBall.exe

using System.Windows.Forms;

public class RicochetBallMain
{
  public static void Main()
  {
    System.Console.WriteLine("The bouncing ball program will begin now.");
    RicochetBallForm RicochetBall_App = new RicochetBallForm();
    Application.Run(RicochetBall_App);

    System.Console.WriteLine("The bouncing ball program has ended.");
  }
}
