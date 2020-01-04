# LinkShortener
Application which is a link shortener service. Exposes both a REST API and a website that can be accessed through a browser. Written in ASP.NET

REST usage:

To obtain a shortened URL send a POST request as follows to https://localhost:44347/api/linkshorten/submit:

Header: Content-Type: application/json

Body: {url:"www.google.com"}

The REST API returns something like the following:

{
    "random_identifier": "A2ACF89705",
    "short_url": "https://localhost:44347/web/A2ACF89705",
    "resolved_url": "http://www.google.com"
}

To resolve a shortened URL send a GET request to https://localhost:44347/api/linkshorten/resolve/<random_identifier>, e.g. https://localhost:44347/api/linkshorten/resolve/129A79D473
The REST API resturns something like the following:

{
    "random_identifier": "A2ACF89705",
    "short_url": "https://localhost:44347/web/A2ACF89705",
    "resolved_url": "http://www.dr.dk"
}

After a URL has been shortened, it can be used by navigating to the short_url from previously, in your browser. This should redirect you to the correct page
