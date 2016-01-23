<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormsApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Task 02</h1>
        <p>
            Start Visual Studio and create new Web Forms App. Look at the files generated and tell what's purpose of each file. 
            Explain the "code behind" model. Print "Hello, ASP.NET" from the C# code and from the aspx code. 
            Display the current assembly location by Assembly.GetExecutingAssembly().Location.
        </p>
    </div>

    <div class="row">
        <ol>
            <li><strong>Purpose of each file:</strong>
                <ul>
                    <li>Account - Asp.Net identity folder</li>
                    <li>App_Data - db file for limited version of SQL</li>
                    <li>App_Start
                        <ul>
                            <li>BundleConfig - javascript and css minification configurations</li>
                            <li>IdentityConfig - configure ASP.NET identity. For example - type of pass, users name length etc.</li>
                            <li>RouteConfig - settings about application routing</li>
                            <li>Startup.Auth - contains information about Owin</li>
                        </ul>
                    </li>
                    <li>Content - css files</li>
                    <li>fonts - font files</li>
                    <li>Models - different classes used in project</li>
                    <li>Scripts - all javascript files used in this projet</li>
                    <li>Bundle.config -information about files path</li>
                    <li>Global.asax - code that runs application start</li>
                    <li>packages.config - informatio about used packages</li>
                    <li>Site.Master - main layout page used in this project</li>
                    <li>Site.Mobile.Master - main layout page used when device is mobile</li>
                    <li>The Startup.cs file establishes the entry point and environment for your ASP.NET 5 application; 
                                it creates services and injects dependencies so that the rest of the app can use them. 
                                The three methods in a default Startup.cs file each handle a different part of setting up the environment:
                        <ul>
                            <li>The constructor Startup() allows us to setup or include the configuration values.</li>
                            <li>ConfigureServices() allows us to add services to the Dependency Injection container.</li>
                            <li>Configure() allows us to add middleware and services to the HTTP pipeline.</li>
                        </ul>
                    </li>
                    <li>ViewSwitcher.ascx - used to redirect different versions</li>
                    <li>Web.config - application configuration file. Here we could have Releasse and Debug version
                        <ul>
                            <li>Release is used when we publish project for server upload</li>
                            <li>Debug is used in development envirenoment</li>
                        </ul>
                    </li>
                </ul>
            </li>
            <li><strong>Explain the "code behind" model</strong>. We have presentation part which is our <strong>aspx</strong> file. 
                Code logic is in our <strong>aspx.cs</strong> file where we have option to manipulate our presentation part and code 
                logic execution. Another part which is class which describe our presentation to C# class is <strong>aspx.designer.cs</strong>.</li>
            <li><strong>From aspx</strong> - "Hello, ASP.NET"</li>
            <li runat="server" ID="txtHi"></li>
            <li runat="server" ID="txtAssembly"></li>
        </ol>
    </div>

</asp:Content>
