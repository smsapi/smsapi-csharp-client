DOCKER_IMAGE = smsapi-tests
PROJECT_PATH = smsapiTests/smsapiTests.csproj

.PHONY: build
build:
	docker build -t $(DOCKER_IMAGE) .

.PHONY: test
test:
	docker run --rm $(DOCKER_IMAGE) \
		dotnet test $(PROJECT_PATH) --configuration Release --no-build --verbosity normal

.PHONY: clean
clean:
	docker rmi -f $(DOCKER_IMAGE)
