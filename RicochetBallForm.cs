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
  private const double refreshRate = 1000/30;   //30 frames per second (60 would be optimal)
  private const double animationRate = 1000/25; //25 updates per second (should be greater than or equal to refreshRate)
  private double distance;
  private double angle;
  private double delta_x;
  private double delta_y;

  private PointF ball = new PointF(formWidth/2, formHeight/2); //location of the ball

  // Create Controls
  private Label title = new Label();
  private Label controlPanel = new Label();
  private Button newButton = new Button();
  private Label distanceText = new Label();
  private TextBox distanceBox = new TextBox();
  private Label angleText = new Label();
  private TextBox angleBox = new TextBox();
  private Button startButton = new Button();
  private Label info = new Label();
  private Button quitButton = new Button();

  // Create Timers
  private static System.Timers.Timer refreshClock = new System.Timers.Timer(refreshRate);
  private static System.Timers.Timer animationClock = new System.Timers.Timer(animationRate);

  public RicochetBallForm()
  {
    // Set up texts
    Text = "Ricochet Ball";
    title.Text = "Ricochet Ball by Anthony Sam";
    title.TextAlign = ContentAlignment.MiddleCenter;
    controlPanel.Text = "Control Panel";
    controlPanel.TextAlign = ContentAlignment.TopCenter;
    newButton.Text = "New";
    distanceText.Text = "Speed: ";
    angleText.Text = "Angle: ";
    startButton.Text = "Start";
    info.Text = "X: " + (ball.X+radius) + "\nY: " + (ball.Y+radius);
    quitButton.Text = "Quit";

    // Set up sizes
    Size = new Size(formWidth, formHeight);
    title.Size = new Size(formWidth, formHeight/10);
    controlPanel.Size = title.Size;
    distanceText.AutoSize = true;
    angleText.AutoSize = true;

    // Set up locations
    controlPanel.Location = new Point(0, formHeight-controlPanel.Height);
    newButton.Location = new Point(formWidth*1/6, formHeight*19/20-newButton.Height/2);
    distanceBox.Location = new Point(formWidth*2/6, formHeight*19/20-distanceBox.Height);
    distanceText.Location = new Point(distanceBox.Left-distanceText.Width, distanceBox.Top);
    angleBox.Location = new Point(distanceBox.Left, distanceBox.Bottom);
    angleText.Location = new Point(angleBox.Left-angleText.Width, angleBox.Top);
    startButton.Location = new Point(formWidth*3/6, newButton.Top);
    info.Location = new Point(formWidth*4/6, formHeight*19/20-info.Height/2);
    quitButton.Location = new Point(formWidth*5/6, newButton.Top);

    // Set up colors
    BackColor = Color.LawnGreen;
    title.BackColor = Color.Cyan;
    controlPanel.BackColor = Color.Magenta;
    distanceText.BackColor = controlPanel.BackColor;
    angleText.BackColor = controlPanel.BackColor;
    newButton.BackColor = Color.DarkOrchid;
    startButton.BackColor = newButton.BackColor;
    quitButton.BackColor = newButton.BackColor;
    info.BackColor = controlPanel.BackColor;

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
    Controls.Add(controlPanel);

    // Define which method each control should call (The methods will be defined below)
    newButton.Click += new EventHandler(reset);
    startButton.Click += new EventHandler(start);
    quitButton.Click += new EventHandler(quit);
    refreshClock.Elapsed += new ElapsedEventHandler(refreshScreen);
    animationClock.Elapsed += new ElapsedEventHandler(updateBall);
  }

  // This method draws on the screen
  protected override void OnPaint(PaintEventArgs e)
  {
    Graphics graphics = e.Graphics;

    graphics.FillEllipse(Brushes.Red, ball.X, ball.Y, radius*2, radius*2); //draws the ball

    base.OnPaint(e);
  }

  protected void reset(Object sender, EventArgs events)
  {
    refreshClock.Stop(); //stop the clocks
    animationClock.Stop();
    ball = new Point(formWidth/2, formHeight/2); //put the ball back
    info.Text = "X: " + (ball.X+radius) + "\nY: " + (ball.Y+radius); //reset the text
    Invalidate();
  }

  protected void start(Object sender, EventArgs events)
  {
    // read the data from the TextBoxes
    try{distance = double.Parse(distanceBox.Text);}catch(System.FormatException){}
    try{angle = double.Parse(angleBox.Text);}catch(System.FormatException){}

    // calculate the delta_x and delta_y values
    delta_x = distance*Math.Cos(angle*Math.PI/180);
    delta_y = distance*Math.Sin(angle*Math.PI/180);
    
    // start the clocks
    refreshClock.Start();
    animationClock.Start();
  }

  protected void quit(Object sender, EventArgs events)
  {
    System.Console.WriteLine("You clicked on the Quit button.");
    Close();
  }

  protected void refreshScreen(Object sender, ElapsedEventArgs events)
  {
    Invalidate();
  }

  protected void updateBall(Object sender, ElapsedEventArgs events)
  {
    // move the ball
    ball.X += (float)delta_x;
    ball.Y -= (float)delta_y;

    // check if the ball has hit the wall
    if(ball.Y <= title.Bottom || ball.Y+radius*2 >= controlPanel.Top) //upper wall or bottom wall
      delta_y *= -1;
    if(ball.X <= 0 || ball.X+radius*2 >= formWidth) //left wall or right wall
      delta_x *= -1;

    // update info.Text
    info.Text = "X: " + (ball.X+radius) + "\nY: " + (ball.Y+radius);
  }
}
