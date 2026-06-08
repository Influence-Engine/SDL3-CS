# SDL3 Image C# Binding
This project provides C# bindings for SDL3_image.

### Version
To prevent version mismatch issues, this binding bundles a build of the native `SDL3_image` library.
Use the details below to track how far this build is from upgrade `main`.
- **Target Component:** `SDL3_image`
- **Bundled Commit:** [0e2eaa9](https://github.com/libsdl-org/SDL_image/commit/0e2eaa923ddea285dfa35c4bf0c0092d3799e2ee) (2044)
- **Upstream Branch/Tag**: `main`
- **Last Compiled/Synced**: 2026-06-08 (yyyy-mm-dd)
**Upstream Dependecy:** This version of `SDL3_image` is compiled to work with the matching version of the core `SDL3` binding found in this repository. Mixing and matching different versions of the native DLLs may cause entry-point exceptions.
