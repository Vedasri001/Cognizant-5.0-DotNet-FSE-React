# 07 - Microservices: Authentication & Authorization (JWT)

Implements all 4 hands-on exercises from the Microservices JWT lab:

1. Implement JWT Authentication in ASP.NET Core Web API
2. Secure an API Endpoint Using JWT (`[Authorize]`)
3. Add Role-Based Authorization (`[Authorize(Roles = "Admin")]`)
4. Validate JWT Token Expiry and Handle Unauthorized Access

## Project: `JwtAuthDemo`

```
JwtAuthDemo/
├── Controllers/
│   ├── AuthController.cs     (login, issues JWT with role claim)
│   ├── SecureController.cs   (Q2: [Authorize]-protected endpoint)
│   └── AdminController.cs    (Q3: Admin-role-protected endpoint)
├── Models/
│   └── LoginModel.cs
├── Program.cs                 (JWT wiring + Q4: auth failure handling)
├── appsettings.json
└── JwtAuthDemo.csproj
```

> **Note:** This code was written and reviewed for correctness against the lab spec,
> but this sandbox doesn't have the .NET SDK available to compile it, so I couldn't
> capture real build/run output here. Run it locally with the commands below — every
> `curl` command's expected response is included so you can confirm your own output
> matches before you commit.

## How to run locally

```bash
cd deepskilling/07-Microservices/JwtAuthDemo
dotnet restore
dotnet run
```
The API will start on something like `https://localhost:5001` (check your console output
for the actual port — copy it into the commands below).

## Testing each exercise

### 1. Login → get a JWT
```bash
curl -k -X POST https://localhost:5001/api/auth/login \
  -H "Content-Type: application/json" \
  -d '{"username":"admin","password":"Admin@123"}'
```
Expected response (token value will differ each run):
```json
{ "Token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..." }
```
Wrong credentials → `401 Unauthorized`.

### 2. Access a secured endpoint (Question 2)
Without a token:
```bash
curl -k https://localhost:5001/api/secure/data
```
Expected: `401 Unauthorized` with body
```json
{"message": "You are not authorized. A valid Bearer token is required."}
```

With a valid token:
```bash
TOKEN="<paste token from step 1>"
curl -k https://localhost:5001/api/secure/data -H "Authorization: Bearer $TOKEN"
```
Expected: `200 OK`
```
"This is protected data."
```

### 3. Role-based authorization (Question 3)
```bash
curl -k https://localhost:5001/api/admin/dashboard -H "Authorization: Bearer $TOKEN"
```
Since the demo login always assigns the `Admin` role, expected: `200 OK`
```
"Welcome to the admin dashboard."
```
A token without the `Admin` role claim would get `403 Forbidden` here.

### 4. Expired/invalid token handling (Question 4)
```bash
curl -k https://localhost:5001/api/secure/data -H "Authorization: Bearer invalid.token.value"
```
Expected: `401 Unauthorized` with the `Token-Expired` header set if the failure was
specifically due to expiry, plus the same custom JSON message as above.

## Save your own output
Once you run this locally, take a screenshot of each `curl` response (or the Swagger UI
at `/swagger` doing the same requests) — that's your real proof-of-work to go with this
code when you push.
