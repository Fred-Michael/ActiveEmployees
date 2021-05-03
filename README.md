# ActiveEmployees
## This is a simple CRUD operation for employees

### Endpoints:

Base Address: http://localhost:{port}



`GET /api/get-all-employees`

**You pass in**: the above route to get all employee details in the database.

**Successful Response:**
```json
HTTP/1.1 200 OK
Content-Type: application/json
{
    "employee_id": “EXXXXX”,
    "first_name": "XXXXX",
    "last_name": "XXXXX",
    "age": "XX",
    "join_date": "XXXX-XX-XX"
},
{
    "employee_id": “EXXXXX”,
    "first_name": "XXXXX",
    "last_name": "XXXXX",
    "age": "XX",
    "join_date": "XXXX-XX-XX"
}
```

**Failed Response:**
```
HTTP/1.1 404 NotFound();
```



`GET /api/get-employee`

**You pass in**: the above route to get an employee

**Successful Response:**
```json
HTTP/1.1 200 OK
Content-Type: application/json
{
    "employee_id": “EXXXXX”,
    "first_name": "XXXXX",
    "last_name": "XXXXX",
    "age": "XX",
    "join_date": "XXXX-XX-XX"
}
```

**Failed Response:**
```
HTTP/1.1 400 BadRequest() OR HTTP/1.1 404 NotFound();
```



`POST /api/add-employee`

**You pass in**: the above route to add an employee

**Successful Response:**
```json
HTTP/1.1 200 OK
Content-Type: application/text

"Employee has been added successfully"
```

**Failed Response:**
```
HTTP/1.1 400 BadRequest();
```



`POST /api/update-employee`

**You pass in**: the above route to update an employee

**Successful Response:**
```json
HTTP/1.1 200 OK
Content-Type: application/text

"Employee detail has been updated"
```

**Failed Response:**
```
HTTP/1.1 400 BadRequest() OR 404 NotFound();
```



`POST /api/delete-employee`

**You pass in**: the above route to delete an employee

**Successful Response:**
```json
HTTP/1.1 200 OK
Content-Type: application/text

"Employee has been deleted successfully"
```

**Failed Response:**
```
HTTP/1.1 400 BadRequest() OR 404 NotFound();
```
