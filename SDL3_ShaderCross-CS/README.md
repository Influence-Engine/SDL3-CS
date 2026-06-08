# SDL3 ShaderCross C# Binding
This project provides C# bindings for SDL3_shadercross.

### Version
To prevent version mismatch issues, this binding bundles a build of the native `SDL3_shadercross` library.
Use the details below to track how far this build is from upgrade `main`.
- **Target Component:** `SDL3_shadercross`
- **Bundled Commit:** [1d8b055](https://github.com/libsdl-org/SDL_shadercross/commit/1d8b0556eefb11a77bc9c28249d16f7a3e0459e9) (154)
- **Upstream Branch/Tag**: `main`
- **Last Compiled/Synced**: 2026-06-08 (yyyy-mm-dd)
**Upstream Dependecy:** This version of `SDL3_shadercross` is compiled to work with the matching version of the core `SDL3` binding found in this repository. Mixing and matching different versions of the native DLLs may cause entry-point exceptions.
