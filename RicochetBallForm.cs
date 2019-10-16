// Author: Anthony Sam
// Program Name: Ricochet Ball

// Name of this file: RicochetBallForm.cs
// Purpose of this file: Define the layout of the user interface (UI) window.
// Purpose of this entire program: This program shows a ball bouncing on the walls.

// Source files in this program: RicochetBallForm.cs, RicochetBallMain.cs
//The source files in this program should be compiled in the order specified below in order to satisfy dependencies.
//  1. RicochetBallForm.cs compiles into library file RicochetBallForm.dll
//  2. RicochetBallMain.cs compiles and links with the dll file above to create RicochetBall.exe
//Compile this file:
//mcs -target:library -r:System.Windows.Forms.dll -r:System.Drawing.dll -out:RicochetBallForm.dll RicochetBallForm.cs

using System;
using System.Windows.Forms;
using System.Drawing;
using System.Timers;

public class RicochetBallForm : Form
{
  private const short formHeight = 1000;
  private const short formWidth = formHeight * 16/9;
  private const short radius = 5;
  private const double refreshRate = 1000/20;   //20 frames per second (60 would be optimal)
  private const double animationRate = 1000/25; //25 updates per second (should be greater than or equal to refreshRate)
  // private double distance = 0; //initialize to 0
  // private double angle = 0; //initialize to 0
  // private double delta_x;
  // private double delta_y;


  private Point ball = new Point(formWidth/2, formHeight/2); //location of the ball

  // Create Controls
  private Label title = new Label();
  private Button newButton = new Button();
  private Label distanceText = new Label();
  private TextBox distanceBox = new TextBox();
  private Label angleText = new Label();
  private TextBox angleBox = new TextBox();
  private Button startButton = new Button();
  private Label info = new Label();
  private Button quitButton = new Button();

  public RicochetBallForm()
  {
    // Set up texts
    title.Text = "Ricochet Ball by Anthony Sam";
    newButton.Text = "New";
    distanceText.Text = "Speed: ";
    angleText.Text = "Angle: ";
    startButton.Text = "Start";
    info.Text = "X: Y: ";
    quitButton.Text = "Quit";

    // Set up sizes
    Size = new Size(formWidth, formHeight);
    title.Size = new Size(formWidth, formHeight/10);
    distanceText.AutoSize = true;
    angleText.AutoSize = true;

    // Set up locations
    newButton.Location = new Point(formWidth*1/6, formHeight*9/10);
    distanceBox.Location = new Point(formWidth*2/6, formHeight*9/10);
    startButton.Location = new Point(formWidth*3/6, formHeight*9/10);
    info.Location = new Point(formWidth*4/6, formHeight*9/10);
    quitButton.Location = new Point(formWidth*5/6, formHeight*9/10);

    // Set up colors
    BackColor = Color.Orange;
    title.BackColor = Color.Cyan;
    newButton.BackColor = Color.DarkOrchid;
    startButton.BackColor = newButton.BackColor;
    quitButton.BackColor = newButton.BackColor;
    info.BackColor = Color.Transparent;

    // Add the controls to the form
    Controls.Add(title);
    Controls.Add(distanceText);
    Controls.Add(angleText);
    Controls.Add(info);
    Controls.Add(newButton);
    Controls.Add(startButton);
    Controls.Add(quitButton);
    Controls.Add(distanceBox);
    Controls.Add(angleBox);

    // Define which method each control should call (The methods will be defined below)
  }

  // This method draws on the screen
  protected override void OnPaint(PaintEventArgs e)
  {
    Graphics graphics = e.Graphics;

    graphics.FillEllipse(Brushes.Red, ball.X, ball.Y, radius*2, radius*2); //draws the ball

    graphics.FillRectangle(Brushes.Yellow, 0, formHeight*9/10, title.Width, title.Height); //draws the yellow bar for the control panel

    base.OnPaint(e);
  }
}
