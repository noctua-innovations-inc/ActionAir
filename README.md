<h1>Dynamic Data View generation through Data Annotation using Microsoft Blazor</h1>

<h2>Problem Definition:</h2>
<p>Have a Microsoft Blazor Grid that can automatically display data collections without having to manually tailor the grid's displaying configuration.</p>

<h2>Solution:</h2>
<p>Use Data Annototations on class properties to dynamically generate grid display configuration for the data collection.</p>
<ul>
    <li><a target="_blank" href="https://dev.azure.com/noctua-innovations/_git/Blazor%20Dynamic%20View%20Generation?path=/ActionAir/Models/Classification.cs">Data Annotate the data POCO...</a></li>
    <li><a target="_blank" href="https://dev.azure.com/noctua-innovations/_git/Blazor%20Dynamic%20View%20Generation?path=/ActionAir/Data/ActionAirClassificationService.cs">Retrieve data into the Data Annotated POCO collection...</a></li>
    <li><a target="_blank" href="https://dev.azure.com/noctua-innovations/_git/Blazor%20Dynamic%20View%20Generation?path=/ActionAir/Shared/Reflection.cs">Create a POCO field view descriptor collection for the grid view...</a></li>
    <li><a target="_blank" href="https://dev.azure.com/noctua-innovations/_git/Blazor%20Dynamic%20View%20Generation?path=/ActionAir/Components/NoctuaDataGrid.razor">Generate the grid view using the field view descriptor collection...</a></li>
</ul>

<h2>Example:</h2>
<ul style="list-style: none;">
    <li><a target="_blank" href="https://action-air.ipscresults.org/#Open">IPSC Action Air Classifications</a></li>
</ul>

<h2>Glossary</h2>

<h3>Microsoft Blazor</h3>
<p>Microsoft Blazor is an open-source web framework developed by Microsoft that allows developers to build interactive and dynamic web applications using C# and .NET instead of traditional web technologies like JavaScript. Blazor enables developers to create web applications with a familiar stack and toolset, making it easier to leverage existing .NET skills and libraries for web development.</p>
<p>Blazor provides a component-based architecture, allowing developers to build reusable UI components and compose them into larger applications. These components are written in C# and Razor syntax, which is similar to HTML with embedded C# code. Blazor components can handle user interactions, maintain state, and render dynamic content.</p>
<p>Blazor integrates well with the broader .NET ecosystem, and you can use the same libraries and tooling that you would use in other .NET applications. This simplifies the development process and allows for code reuse across different types of applications, such as desktop, mobile, and web.</p>

<h3>C# Attributes</h3>
<p>In C#, attributes are metadata annotations that provide additional information about code elements, such as classes, methods, properties, and parameters. Attributes are used to add descriptive and declarative information to the elements they are applied to. They do not affect the runtime behavior of the code but are used by tools, frameworks, and libraries to influence their behavior or to extract information about the code.</p>

<h3>C# Data Annotations</h3>
<p>Microsoft Data Annotations, often referred to as "Data Annotations," is a set of <b>C# Attributes</b> that are part of the System.ComponentModel.DataAnnotations namespace in the .NET framework. These attributes provide a declarative way to add metadata and validation rules to classes and properties in C# or VB.NET. They are commonly used for data validation, specifying formatting rules, and other data-related tasks. Data Annotations are frequently employed in various parts of .NET, including ASP.NET MVC, Entity Framework, and more.</p>
<p>Data Annototations are well established C# Attributes that first became generally available on April 12, 2010.<p>

<h3>Data Transfer Object (DTO) & Entity Framework Plain Old C# Object (POCO)</h3>
<p>A Data Transfer Object (DTO) is a design pattern used in software development to transfer data between different parts of a program or between different software systems. DTOs are simple, plain data structures that typically represent a subset of data from a more complex domain model or database entity. They are primarily used for efficiently passing data between layers of an application, such as between a client and a server, or between different components of a software system.</p>
<p>An Entity Framework (EF) Plain Old C# Object (POCO) is a DTO that is used to transfer data between the persistent data storage the software processes</p>

<h3>Cross-Cutting Concerns</h3>
<p>Cross-cutting concerns, in the context of software development, refer to aspects of a program or system that affect multiple parts of the application but are not localized to a specific module or component. These concerns "cut across" various parts of the codebase, often in a way that makes them difficult to modularize within individual components. They are typically orthogonal to the core functionality of the software and can include aspects such as security, logging, error handling, and performance optimization.</p>

<h3>Single Responsibility Principle (SRP)</h3>
<p>The Single Responsibility Principle (SRP) is one of the five SOLID principles of object-oriented programming and design. It is a fundamental concept in software engineering that emphasizes that a class or module should have only one reason to change. In other words, a class or module should have a single responsibility or a single well-defined task.</p>

<h3>Open-Closed Principle (OCP)</h3>
<p>"Software entities (such as classes, modules, functions, etc.) should be open for extension but closed for modification."</p>
