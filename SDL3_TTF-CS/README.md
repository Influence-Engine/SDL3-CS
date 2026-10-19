# SDL3 TTF C# Binding
This project provides C# bindings for SDL3_ttf.

### Version
To prevent version mismatch issues, this binding bundles a build of the native `SDL3_ttf` library.
Use the details below to track how far this build is from upgrade `main`.
- **Target Component:** `SDL3_ttf`
- **Bundled Commit:** [fc8d545](https://github.com/libsdl-org/SDL_ttf/commit/fc8d545f3bf2298c40f41fda5225eb6328fb85f6) (1303)
- **Upstream Branch/Tag**: `main`
- **Last Compiled/Synced**: 2026-10-19 (yyyy-mm-dd)
**Upstream Dependecy:** This version of `SDL3_ttf` is compiled to work with the matching version of the core `SDL3` binding found in this repository. Mixing and matching different versions of the native DLLs may cause entry-point exceptions.
