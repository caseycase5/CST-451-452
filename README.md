Inventory Management Application README

This application was created for my CST-451/452 Senior Project. It was created by a team of one over the course of 8 weeks 
(really just 4 weeks after the required planning/documentation phases), which is why the features are very basic at this point.

PROJECT PURPOSE:
The idea behind this project was to create an application that allows an easy UI for managing an inventory of items, personnel, 
or anything else that needs to be tracked. The tracked item can be changed easily by simply adjusting the column headers and 
adjusting the database calls in the "DataService" class.

The application currently uses a .mdf file to create a local database on the user's machine, but this connection can be changed 
to utilize an external database connection if that is what the user wants to use. An external database would allow all users of 
the application to have access to the same dataset at all times. This can be changed by changing the connection string within 
the "DataService" class under the "NewConnection" method.

FEATURES NOT IMPLEMENTED:
There were a few things I was not able to get to, but wanted to include from my early phases. One of the biggest ones I was not 
able to add was column sorting. I wanted the user to be able to click the header of one of the columns in the inventory display 
screen to be able to sort the column from lowest to highest value or opposite. This would be very helpful with a larger database
that can be difficult to read through. I also wanted to add filtering to the column headers to allow the user to sort the output
they see even more.

APPLICATION INSTALLATION:
While this repo includes all source code, allowing for changes to any area of the application, if you simply want to run the 
application locally on your computer, you need to access the bin folder. Copy the release folder to whatever system you want it
to run on, open the release folder, and run the .exe file. As long as your system has Microsoft SQL server installed on it, the 
database should run without any issues. 

InventoryManagement -> bin -> Release
