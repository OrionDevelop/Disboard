# Disboard Tests

Disboard sends a real request once because generate a mock data by request uri, body and response body.  
In the second and subsequent request, Disboard use mock data for tests.  
If tests attempt to send the actual request with the second and subsequent requests, tests will fail. 