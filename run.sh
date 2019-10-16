#!/bin/bash
#In the official documentation the line above always has to be the first line of any script file.

# Author: Anthony Sam
# Program Name: Ricochet Ball

#This is a bash shell script to be used for compiling, linking, and executing the C# (.cs) files.
#Execute this file by navigating the terminal window to the folder where this file resides, and then enter either of the commands below:
#  sh run.sh OR ./run.sh

echo "First, remove any potentially outdated .dll or .exe files using the keyword rm"
rm *.dll
rm *.exe

echo "Display the list of the remaining files in the terminal using the keyword ls"
ls -l

echo "Compile RicochetBallForm.cs to create the file: RicochetBallForm.dll"
mcs -target:library -r:System.Windows.Forms.dll -r:System.Drawing -out:RicochetBallForm.dll RicochetBallForm.cs

echo "Compile RicochetBallMain.cs and link the previously created .dll file(s) to create an executable (.exe) file."
mcs -r:System.Windows.Forms.dll -r:RicochetBallForm.dll -out:RicochetBall.exe RicochetBallMain.cs

echo "Display the updated list of files in the folder, now including the newly created .dll and .exe files"
ls -l

echo "Run the program."
./RicochetBall.exe

echo "The script has terminated."
