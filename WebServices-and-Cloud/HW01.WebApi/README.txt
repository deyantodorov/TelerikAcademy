Requirements:

Visual Studio - 2013, 2015

Sql Server 2014

Build soluctions to restore packages

-----------------------

ArtistSystem - this is sever logic. You need to run it, before testing HttpClient or Single Page Application

ArtistSystemConsoleHttpClient - this is console HttpClient which test ArtistSystem, before use it run ArtistSystem and leave it started.

ArtistSystemSinglePageApplication - this is SPA which works with ArtistSystem, before use it run ArtistSystem and leave it started.