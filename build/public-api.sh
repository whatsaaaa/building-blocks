#!/usr/bin/env bash
# Declares every public member that is not yet in a PublicAPI file, using the analyzer's own code fix.
# Run it after adding public API, then read the diff: every new line is a promise to products.
set -euo pipefail
cd "$(dirname "$0")/.."
dotnet format analyzers Whatsaaaa.BuildingBlocks.slnx --diagnostics RS0016 --verbosity minimal
git --no-pager diff --stat -- '*PublicAPI.Unshipped.txt'
