# SDL3 C# Binding
This project provides C# bindings for SDL3.

### Version
To prevent version mismatch issues, this binding bundles a build of the native `SDL3` library.
Use the details below to track how far this build is from upgrade `main`.
- **Target Component:** `SDL3`
- **Bundled Commit:** [66f946e](https://github.com/libsdl-org/SDL/commit/66f946e99bc58b7916e8787c207f677050140e95) (22860)
- **Upstream Branch/Tag**: `main`
- **Last Compiled/Synced**: 2026-11-02 (yyyy-mm-dd)
**Upstream Dependecy:** This version of `SDL3-CS` is compiled to work with the matching version of the core `SDL3` binding found in this repository. Mixing and matching different versions of the native DLLs may cause entry-point exceptions.
