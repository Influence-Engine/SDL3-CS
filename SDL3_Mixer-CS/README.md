# SDL3 Mixer C# Binding
This project provides C# bindings for SDL3_mixer.

### Version
To prevent version mismatch issues, this binding bundles a build of the native `SDL3_mixer` library.
Use the details below to track how far this build is from upgrade `main`.
- **Target Component:** `SDL3_mixer`
- **Bundled Commit:** [df966f6](https://github.com/libsdl-org/SDL_mixer/commit/df966f698e18ae849bd92796a26311e79c555718) (2355)
- **Upstream Branch/Tag**: `main`
- **Last Compiled/Synced**: 2026-11-02 (yyyy-mm-dd)
**Upstream Dependecy:** This version of `SDL3_mixer` is compiled to work with the matching version of the core `SDL3` binding found in this repository. Mixing and matching different versions of the native DLLs may cause entry-point exceptions.
