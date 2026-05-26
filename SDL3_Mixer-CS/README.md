# SDL3 Mixer C# Binding
This project provides C# bindings for SDL3_mixer.

### Version
To prevent version mismatch issues, this binding bundles a build of the native `SDL3_mixer` library.
Use the details below to track how far this build is from upgrade `main`.
- **Target Component:** `SDL3_mixer`
- **Bundled Commit:** [29a1fb1](https://github.com/libsdl-org/SDL_mixer/commit/29a1fb14addad54be2c9954a9c5d9bfb949c2b3e)
- **Upstream Branch/Tag**: `main`
- **Last Compiled/Synced**: 2026-05-26
**Upstream Dependecy:** This version of `SDL3_mixer` is compiled to work with the matching version of the core `SDL3` binding found in this repository. Mixing and matching different versions of the native DLLs may cause entry-point exceptions.