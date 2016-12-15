Pagination-Kata
===============================

This Kata will help candidates learn about TDD development on green and brown fields. 
The .Net version is using NUnit & NSubstitute while the Java implementation is based on JUnit and mockito.

Table of Contents
=================

  1. Preparing your machine
  2. Pagination Kata
  3. Understanding solution
  4. Licensing
  5. Contacts
  6. Credits

1. Preparing your machine
===============

1.1. Java
-----------------

* Download the package and unzip it. Next, import the project inside the Java folder as a Maven project inside Eclipse.


2.1. Installing Visual Studio
-----------------

* Download visual studio installation from the link below and install it on your machine:

   https://www.visualstudio.com/en-us/products/visual-studio-community-vs.aspx

2.2. Adding Visual Studio extensions
--------------------------------

* Because we will be using Nunit, it will be useful to add Nunit test adapter 3 extension to visual studio in order to run tests from within the test explorer:

   Open Visual Studio and go to Tools > Extensions and Updates.
   Search for NUnit test adapter on the online gallery and add it.

2.3. Creating the test project
---------------------------

* Finally, create a new library project and add reference to the following packages via Nuget Manager console:

   Open Visual Studio and go to Tools > NuGet package manager > NuGet package manager console and type these commands.

   Install-Package NUnit
   
   Install-Package NSubstitute
   
   2. Pagination Kata
===============

You would like to paginate the items you are retrieving from the database before displaying them on a certain page.
In order to do so, you need to return the first and last page numbers. The Previous and next page numbers of the required page. 

The rules are:

- The database can return 0 or more items.
- First page number is 0 if there are no items to display.
- Last page number is 0 if there are no items to display.
- Previous page number is:
	* -1 if there are no items to display
	* 0 if previous page does not exist.
  * else required page - 1
- Next page number is:
	* -1 if there are no items to display
	* 0 if next page does not exist.
  * required page + 1
  
Examples:


