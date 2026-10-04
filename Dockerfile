# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:10.0-alpine AS build
WORKDIR /source

RUN apk add --no-cache clang build-base zlib-dev

COPY src/MbaCoach/*.csproj ./src/MbaCoach/
WORKDIR /source/src/MbaCoach
RUN dotnet restore -r linux-musl-x64

COPY src/MbaCoach/ ./
RUN dotnet publish -r linux-musl-x64 -c Release -o /app --no-restore

# Runtime Stage
FROM mcr.microsoft.com/dotnet/runtime-deps:10.0-alpine AS final
WORKDIR /app

RUN apk add --no-cache ca-certificates tzdata

RUN adduser -u 1000 -D appuser && \
    mkdir -p /app/data /app/temp && \
    chown -R appuser:appuser /app

USER appuser

COPY --from=build --chown=appuser:appuser /app/MbaCoach ./MbaCoach

ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1 \
    TMPDIR=/app/temp

ENTRYPOINT ["./MbaCoach"]