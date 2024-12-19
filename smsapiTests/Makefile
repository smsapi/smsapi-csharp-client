DOCKER_IMAGE = smsapi-csharp-client-tests
PROJECT_PATH = smsapiTests/smsapiTests.csproj
DOTNET_VERSIONS = 6.0 7.0 8.0 9.0

.PHONY: build
build:
	docker build -t $(DOCKER_IMAGE) -f Dockerfile ../

.PHONY: test
test:
	@for version in $(DOTNET_VERSIONS); do \
		echo "Running tests on .NET $$version"; \
		docker run --rm \
        			-w /app \
        			$(DOCKER_IMAGE) \
        			dotnet test $(PROJECT_PATH) --configuration Release --no-build --framework net$$version; \
	done

.PHONY: clean
clean:
	docker rmi -f $(DOCKER_IMAGE)
