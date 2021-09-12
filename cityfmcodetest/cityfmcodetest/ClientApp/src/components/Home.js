import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <h1>Hello, CityFM!</h1>
        <p>Welcome to your candidate test application, built with:</p>
        <ul>
          <li><a href='https://get.asp.net/'>ASP.NET Core</a> and <a href='https://msdn.microsoft.com/en-us/library/67ef8sbd.aspx'>C#</a> for cross-platform server-side code</li>
          <li><a href='https://facebook.github.io/react/'>React</a> for client-side code</li>
          <li><a href='http://getbootstrap.com/'>Bootstrap</a> for layout and styling</li>
        </ul>
        <p>I have set up these features:</p>
        <ul>
          <li><strong>Client-side navigation.</strong> For example, click <em>Products</em> then <em>Back</em> to return here.</li>
          <li><strong>Dotnet Entity Framework</strong> for model migrations and query stuff from the local SQLite database.</li>
          <li><strong>Swagger</strong> for <a href="/swagger">API documentation</a>.</li>
        </ul>
        <p>Production tab:</p>
        <ul>
          <li><strong>Fetch Data.</strong> Click This button to fetch all products from the API <code>http://alltheclouds.com.au/api/products</code> to the local SQLite database, also display to the page.</li>
          <li><strong>Get Data.</strong> For retrieveing all product data directly from the database and display to the page.</li>
          <li><strong>Clear Data</strong> to yeet every single entries in the <code>Product</code> table. After that, you can no longer get data from the second button.</li>
        </ul>
        <p>The <code>ClientApp</code> subdirectory is a standard React application based on the <code>create-react-app</code> template. If you open a command prompt in that directory, you can run <code>npm</code> commands such as <code>npm test</code> or <code>npm install</code>.</p>
      </div>
    );
  }
}
