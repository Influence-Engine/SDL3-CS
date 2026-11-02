# SDL3 ShaderCross C# Binding
This project provides C# bindings for SDL3_shadercross.

### Version
To prevent version mismatch issues, this binding bundles a build of the native `SDL3_shadercross` library.
Use the details below to track how far this build is from upgrade `main`.
- **Target Component:** `SDL3_shadercross`
- **Bundled Commit:** [1ff05be](https://github.com/libsdl-org/SDL_shadercross/commit/1ff05bec573988a98ef9e0260b4da44f512b8367) (157)
- **Upstream Branch/Tag**: `main`
- **Last Compiled/Synced**: 2026-11-02 (yyyy-mm-dd)
**Upstream Dependecy:** This version of `SDL3_shadercross` is compiled to work with the matching version of the core `SDL3` binding found in this repository. Mixing and matching different versions of the native DLLs may cause entry-point exceptions.
