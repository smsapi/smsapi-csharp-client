# Running Tests Locally with Makefile

This project uses a `Makefile` to simplify the process of running tests locally. The `Makefile` defines the necessary commands to build the Docker image and run tests with multiple .NET versions.

## Prerequisites

Before running tests locally, ensure you have the following installed:

- [Docker](https://www.docker.com/get-started): Docker is used to run the tests inside a container.
- [Make](https://www.gnu.org/software/make/): Make is used to invoke commands defined in the `Makefile`.

## Project Structure

This project includes the following key files and directories:

- `Makefile`: The file that defines the commands for building and testing the project.
- `smsapiTests/`: The directory containing the test project (`smsapiTests.csproj`).
- `Dockerfile`: The file that defines the Docker container used to run the tests.

## Running Tests

The tests are executed inside a Docker container, which ensures that the correct environment is used for all .NET versions specified.

### 1. Build project
```bash
make build
```

### 2. Run tests
```bash
make test
```
