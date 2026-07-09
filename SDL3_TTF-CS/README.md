# SDL3 TTF C# Binding
This project provides C# bindings for SDL3_ttf.

### Version
To prevent version mismatch issues, this binding bundles a build of the native `SDL3_ttf` library.
Use the details below to track how far this build is from upgrade `main`.
- **Target Component:** `SDL3_ttf`
- **Bundled Commit:** [a42434b](https://github.com/libsdl-org/SDL_ttf/commit/a42434b8c96daaf7650dbd0befe480c090d1c2eb) (1298)
- **Upstream Branch/Tag**: `main`
- **Last Compiled/Synced**: 2026-07-09 (yyyy-mm-dd)
**Upstream Dependecy:** This version of `SDL3_ttf` is compiled to work with the matching version of the core `SDL3` binding found in this repository. Mixing and matching different versions of the native DLLs may cause entry-point exceptions.
