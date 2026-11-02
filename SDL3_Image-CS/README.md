# SDL3 Image C# Binding
This project provides C# bindings for SDL3_image.

### Version
To prevent version mismatch issues, this binding bundles a build of the native `SDL3_image` library.
Use the details below to track how far this build is from upgrade `main`.
- **Target Component:** `SDL3_image`
- **Bundled Commit:** [1b7d205](https://github.com/libsdl-org/SDL_image/commit/1b7d205053b26bc1b9f6341ed1d216ee3a057ded) (2076)
- **Upstream Branch/Tag**: `main`
- **Last Compiled/Synced**: 2026-11-02 (yyyy-mm-dd)
**Upstream Dependecy:** This version of `SDL3_image` is compiled to work with the matching version of the core `SDL3` binding found in this repository. Mixing and matching different versions of the native DLLs may cause entry-point exceptions.
