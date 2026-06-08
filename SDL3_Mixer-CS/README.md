# SDL3 Mixer C# Binding
This project provides C# bindings for SDL3_mixer.

### Version
To prevent version mismatch issues, this binding bundles a build of the native `SDL3_mixer` library.
Use the details below to track how far this build is from upgrade `main`.
- **Target Component:** `SDL3_mixer`
- **Bundled Commit:** [52afb20](https://github.com/libsdl-org/SDL_mixer/commit/52afb20701c7f67cf1aa27046378835be1af2f1c) (2289)
- **Upstream Branch/Tag**: `main`
- **Last Compiled/Synced**: 2026-06-08 (yyyy-mm-dd)
**Upstream Dependecy:** This version of `SDL3_mixer` is compiled to work with the matching version of the core `SDL3` binding found in this repository. Mixing and matching different versions of the native DLLs may cause entry-point exceptions.
