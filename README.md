# Smokeball.SEO.WPF
WPF and .NET Core Application for Smokeball SEO
CONTENTS OF THIS FILE
---------------------

 * Introduction
 * Requirement
 * Design Decisions


INTRODUCTION
------------

This is a sample project build to complete an assignment as part of a recruitment process

REQUIREMENT
------------

The CEO from Smokeball is very interested in SEO and how this can improve Sales. Every morning he
logs in to google.com.au and types in the same key words “conveyancing software” and counts
down to see where and how many times their company, www.smokeball.com.au sits on the list.
Seeing the CEO do this every day, a smart software developer at Smokeball decides to write a small
application for him that will automatically perform this operation and return the result to the screen.
They design and code some software that receives a string of keywords, and a string URL. This is
then processed to return a string of numbers for where the resulting URL is found in Google. For
example “1, 10, 33” or “0”.
The CEO is only interested if their URL appears in the first 100 results.

DESIGN DECISIONS 
----------------

 * Wpf for UI.

 * .NET Core for Backend code.

The application is designed in 3 layers - WPF - UI, Business Layer that has all the logic for data manipulation and finally the Service Layer that builds the communication 
with the external url and returns the required data.

Asynchronous calls have not been implemented because of the small scale of the nature of data type to be returned

Any external library is not used to interact like HtmlAgility or Google API is not used to get response from the google url

Microsoft.Extentions.Logger is used to log data for the application. Its not used in the entire project because of the limited timeframe

Unit Test project is also added which uses XUnit

The WPF UI is just a basic UI design as the developer doesn't have extensive knowledge on WPF

Smokeball.SEO.WPF is the startup project which interacts with Business class and that in turn interacts with Service layer through DI inbuilt in .NET core

Love the limitations, and craziness, of this project.
