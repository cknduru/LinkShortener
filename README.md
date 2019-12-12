# LinkShortener
Application which is a link shortener service. Exposes both a REST API and a website that can be accessed through a browser. Written in ASP.NET

REST usage:

To obtain a shortened URL send a POST request as follows to https://localhost:44347/api/linkshorten/submit:

Header: Content-Type: application/json

Body: {url:"www.google.com"}

The REST API returns something like the following:

{
    "unresolved_url": "129A79D473",
    "full_unresolved_url": "https://localhost:44347/129A79D473",
    "resolved_url": "www.google.com"
}



To resolve a shortened URL send a GET request to https://localhost:44347/api/linkshorten/resolve/<unresolved_url>, e.g. https://localhost:44347/api/linkshorten/resolve/129A79D473
The REST API resturns something like the following:

{
    "unresolved_url": "129A79D473",
    "full_unresolved_url": "https://localhost:44347/129A79D473",
    "resolved_url": "www.google.com"
}
