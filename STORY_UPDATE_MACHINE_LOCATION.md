# User Story: Update Machine Location

## Story ID

**MACH-102**: Update Machine Location via API

---

## Story

**As a** plant operations manager  
**I want** to update the location of a machine through the API  
**So that** I can keep accurate records when equipment is moved between sites

---

## Business Context

Plant equipment (excavators, bulldozers, cranes, etc.) are frequently relocated between construction sites and facilities. Currently, there is no way to update machine locations without direct database access. This story provides an API endpoint to update machine locations programmatically.

---

## Acceptance Criteria

### AC1: Endpoint Implementation

- PATCH endpoint exists at `/api/machines/{id}/location`
- Machine's location is updated in the database
- Appropriate success response is returned

### AC2: Valid Request Format

- Request body contains a location field
- Location must be a non-empty string
- Location has maximum length of 200 characters
- Example request format:

```json
{
  "location": "Construction Site D - East Wing"
}
```

### AC3: Machine Not Found Handling

- Returns `404 Not Found` when machine ID doesn't exist
- Returns proper ProblemDetails error response
- Error message clearly indicates machine not found

### AC4: Invalid Location Validation

- Returns `422 Unprocessable Entity` for empty location
- Returns `422 Unprocessable Entity` for whitespace-only location
- Returns `422 Unprocessable Entity` for location exceeding 200 characters
- Validation errors return proper ProblemDetails response

### AC5: Success Response

- Returns `204 No Content` status code on successful update

### AC6: Swagger Documentation

- Endpoint appears in Swagger UI
- Request body schema is documented
- All response status codes are documented (204, 404, 422)
- Response examples provided for each status code
- Summary and description included

### AC7: Automated Tests

- Integration tests cover successful location update
- Integration tests cover machine not found scenario
- Integration tests cover empty location validation
- Integration tests cover whitespace location validation
- Integration tests cover location length validation
- All tests pass successfully

---

## Technical Requirements

### Endpoint Specification

**HTTP Method**: `PATCH`  
**Route**: `/api/machines/{id}/location`  
**Tags**: `Machines`

### Request Body

```json
{
  "location": "string (required, max 200 characters, not empty)"
}
```

### Response Codes

- `204 No Content` - Location updated successfully
- `422 Unprocessable Entity` - Invalid input (empty location, too long, etc.)
- `404 Not Found` - Machine with specified ID doesn't exist
- `500 Internal Server Error` - Unexpected server error

### Success Response (204 No Content)

```json
{}
```

### Error Response (400 Bad Request)

```json
{
  "type": "https://tools.ietf.org/html/rfc9110#section-15.5.1",
  "title": "Bad Request",
  "status": 400,
  "detail": "Location cannot be empty or whitespace only.",
  "instance": "/api/machines/1/location"
}
```

### Error Response (422 Unprocessable Entity)

```json
{
  "type": "https://tools.ietf.org/html/rfc9110#section-15.5.5",
  "title": "Unprocessable Entity",
  "status": 422,
  "detail": "Machine with ID 1 was not found.",
  "instance": "/api/machines/1/location"
}
```

---

## Implementation Guidelines

### Must Follow Existing Patterns

Your implementation **must** follow the established patterns demonstrated in `GetMachines.cs`:

1. ✅ Create endpoint in `MachineApi.Api/Endpoints/UpdateMachineLocation.cs`
2. ✅ Use `RouteGroupBuilder` extension method pattern
3. ✅ Use strongly typed `Results<>` union types for return values
4. ✅ Use `TypedResults` for responses
5. ✅ Implement proper Swagger documentation:
   - `.WithSummary()`
   - `.WithDescription()` (optional)
   - `.Produces<>()` for success responses
   - `.ProducesProblem()` for error responses
6. ✅ Add `[SwaggerResponseExample]` attributes for response examples
7. ✅ Use async/await properly throughout
8. ✅ Follow REST conventions for route naming
9. ✅ Register endpoint using `routeGroupBuilder` in `Program.cs`

### Validation Requirements

- Location must not be null
- Location must not be empty or whitespace only
- Location must not exceed 200 characters
- Return appropriate `ProblemDetails` for validation failures

### Database Operations

- Use `FirstOrDefaultAsync()` to find the machine
- Update the `Location` property
- Use `SaveChangesAsync()` to persist changes
- Handle any database exceptions appropriately

---

## Definition of Done

- [ ] Endpoint implemented following existing patterns
- [ ] Request validation implemented
- [ ] Appropriate HTTP status codes returned
- [ ] Swagger documentation complete with examples
- [ ] Response example classes created (204, 404, 422)
- [ ] Integration tests written and passing
- [ ] Code follows existing conventions and style
- [ ] No linter warnings or errors
- [ ] All existing tests still pass
- [ ] Manual testing completed in Swagger UI

---

## Test Cases to Implement

Create appropriate integration tests in MachineApiTests.cs. At least 80% code coverage is required.

---

## Out of Scope

The following are **NOT** part of this story:

- ❌ Updating other machine properties (name, serial number, etc.)
- ❌ Bulk location updates
- ❌ Location history/audit trail
- ❌ Location validation against a predefined list
- ❌ Authentication/authorization
- ❌ Rate limiting
- ❌ Caching

---

## Dependencies

- None. This story can be completed independently.

---

## Questions?

If any requirements are unclear:

1. Review the `GetMachines.cs` endpoint as the reference implementation
2. Check the `DeleteMachine.cs` endpoint for comparison (but note it has intentional issues - don't copy its patterns!)
3. Ask for clarification if validation rules are ambiguous

---

## Success Criteria

This story is complete when:

- ✅ A plant operations manager can update machine locations via the API
- ✅ Invalid requests are properly rejected with clear error messages
- ✅ The API is well-documented and easy to use
- ✅ The implementation is consistent with existing code patterns
- ✅ All tests pass and provide good coverage
