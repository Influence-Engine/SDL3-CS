# SDL3 TTF C# Binding
This project provides C# bindings for SDL3_ttf.

### Version
To prevent version mismatch issues, this binding bundles a build of the native `SDL3_ttf` library.
Use the details below to track how far this build is from upgrade `main`.
- **Target Component:** `SDL3_ttf`
- **Bundled Commit:** [5aeb009](https://github.com/libsdl-org/SDL_ttf/commit/5aeb0091923d09d9be6b7b49612697308d8238d1) (1304)
- **Upstream Branch/Tag**: `main`
- **Last Compiled/Synced**: 2026-11-02 (yyyy-mm-dd)
**Upstream Dependecy:** This version of `SDL3_ttf` is compiled to work with the matching version of the core `SDL3` binding found in this repository. Mixing and matching different versions of the native DLLs may cause entry-point exceptions.
