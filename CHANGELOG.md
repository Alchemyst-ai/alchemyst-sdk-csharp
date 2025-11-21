# Changelog

## 0.1.0 (2025-11-21)

Full Changelog: [v0.0.1...v0.1.0](https://github.com/Alchemyst-ai/alchemyst-sdk-csharp/compare/v0.0.1...v0.1.0)

### ⚠ BREAKING CHANGES

* **client:** use `DateTimeOffset` instead of `DateTime`
* **client:** flatten service namespaces
* **client:** interpret null as omitted in some properties
* **client:** make models immutable

### Features

* **api:** manual updates ([78be0e1](https://github.com/Alchemyst-ai/alchemyst-sdk-csharp/commit/78be0e1dfdc291a8b20cad45228a5055140b0024))
* **api:** manual updates ([59b1993](https://github.com/Alchemyst-ai/alchemyst-sdk-csharp/commit/59b19932e155b015bf8fb1e37a564fec7bad62ce))
* **api:** manual updates ([3cf2b27](https://github.com/Alchemyst-ai/alchemyst-sdk-csharp/commit/3cf2b27b41e90cdf56688dd5cb2c45ff085acf14))
* **client:** add `HttpResponse.ReadAsStream` method ([7e023a3](https://github.com/Alchemyst-ai/alchemyst-sdk-csharp/commit/7e023a32159008be61c814ee75831a9b92f987c3))
* **client:** add cancellation token support ([9d5c51c](https://github.com/Alchemyst-ai/alchemyst-sdk-csharp/commit/9d5c51cac737948e7ee7e9b873b05db1bc333fe3))
* **client:** add response validation option ([7c98a82](https://github.com/Alchemyst-ai/alchemyst-sdk-csharp/commit/7c98a82cce955ab890ca697301a1c0a161bad3c8))
* **client:** add retries support ([7c0440a](https://github.com/Alchemyst-ai/alchemyst-sdk-csharp/commit/7c0440a7727e42e80f0713eef5182759f5acb4c1))
* **client:** add support for option modification ([b7f058f](https://github.com/Alchemyst-ai/alchemyst-sdk-csharp/commit/b7f058f047480292b114ead4000f60e39bf05449))
* **client:** additional methods for positional params ([ffeb045](https://github.com/Alchemyst-ai/alchemyst-sdk-csharp/commit/ffeb045e2f2658785e1fe8a0192704a69f052b2c))
* **client:** make models immutable ([6d4e186](https://github.com/Alchemyst-ai/alchemyst-sdk-csharp/commit/6d4e186c18ec9ad39bfbf18116597dad5d3a5fba))
* **client:** send `User-Agent` header ([576b145](https://github.com/Alchemyst-ai/alchemyst-sdk-csharp/commit/576b14527e8bae3f8713d98daa37ff05ff3b3fb5))
* **client:** send `X-Stainless-Arch` header ([3a6d668](https://github.com/Alchemyst-ai/alchemyst-sdk-csharp/commit/3a6d6686aef7779cdfae1b16e35a1b7484777770))
* **client:** send `X-Stainless-Lang` and `X-Stainless-OS` headers ([133fab3](https://github.com/Alchemyst-ai/alchemyst-sdk-csharp/commit/133fab32a0ba26fa93ec1ad030550b720bca9bab))
* **client:** send `X-Stainless-Package-Version` headers ([60a8f1a](https://github.com/Alchemyst-ai/alchemyst-sdk-csharp/commit/60a8f1a8215d133751e7632c79f75bfb557d0ace))
* **client:** send `X-Stainless-Runtime` and `X-Stainless-Runtime-Version` ([482ac0d](https://github.com/Alchemyst-ai/alchemyst-sdk-csharp/commit/482ac0dfdfaaf75b5cc4d064e5882fb96934e1dd))
* **client:** send `X-Stainless-Timeout` header ([992fa33](https://github.com/Alchemyst-ai/alchemyst-sdk-csharp/commit/992fa33d627f3a4750ae2cb163e045a826a941bb))
* **client:** support request timeout ([1173a22](https://github.com/Alchemyst-ai/alchemyst-sdk-csharp/commit/1173a228938201971143d18f2a59aea0da74eace))


### Bug Fixes

* **client:** interpret null as omitted in some properties ([47fecd1](https://github.com/Alchemyst-ai/alchemyst-sdk-csharp/commit/47fecd19a5a37c5fee6b022206fa1cfc557e198d))
* **client:** use `DateTimeOffset` instead of `DateTime` ([8ede18a](https://github.com/Alchemyst-ai/alchemyst-sdk-csharp/commit/8ede18a45dae992e9bde0dfae9f5652ff7b5910c))
* **internal:** minor project fixes ([3c3ad26](https://github.com/Alchemyst-ai/alchemyst-sdk-csharp/commit/3c3ad26d5321cea3a30fd407b7515858422713d8))


### Performance Improvements

* **client:** optimize header creation ([669c1f4](https://github.com/Alchemyst-ai/alchemyst-sdk-csharp/commit/669c1f4b1979b9aa82cdedd771f8c992c5dc161b))


### Chores

* **client:** change name of underlying properties for models and params ([0707377](https://github.com/Alchemyst-ai/alchemyst-sdk-csharp/commit/07073773b1cc80f5407aaf89296c364a4c048e21))
* **client:** deprecate some symbols ([8f84a6c](https://github.com/Alchemyst-ai/alchemyst-sdk-csharp/commit/8f84a6c43c57f58b7d76fde08d5e288331e4743f))
* **client:** simplify field validations ([7c98a82](https://github.com/Alchemyst-ai/alchemyst-sdk-csharp/commit/7c98a82cce955ab890ca697301a1c0a161bad3c8))
* configure new SDK language ([21b8cb8](https://github.com/Alchemyst-ai/alchemyst-sdk-csharp/commit/21b8cb861241019c358b041ece7dc511d54c4c3e))
* **docs:** include more properties in examples ([8ca01f5](https://github.com/Alchemyst-ai/alchemyst-sdk-csharp/commit/8ca01f5dbd32bd6d8bee93c38b0d89190475c35c))
* **internal:** add prism log file to gitignore ([b35bb0a](https://github.com/Alchemyst-ai/alchemyst-sdk-csharp/commit/b35bb0a0ae7399e325134a922eeee3e30039d07b))
* **internal:** codegen related update ([ba0945d](https://github.com/Alchemyst-ai/alchemyst-sdk-csharp/commit/ba0945d3785377123f22f28150767d7144655cfd))
* **internal:** codegen related update ([8667cb2](https://github.com/Alchemyst-ai/alchemyst-sdk-csharp/commit/8667cb266f5689d9fae2e4d23bdf8b6110c05bb0))
* **internal:** delete empty test files ([f9d55e8](https://github.com/Alchemyst-ai/alchemyst-sdk-csharp/commit/f9d55e810af0119cd02d3ac051195d1cb4307784))
* **internal:** extract `ClientOptions` struct ([7ad1a58](https://github.com/Alchemyst-ai/alchemyst-sdk-csharp/commit/7ad1a5885f012dfe04c11438e0ec8934abbe020b))
* **internal:** improve devcontainer ([91779cb](https://github.com/Alchemyst-ai/alchemyst-sdk-csharp/commit/91779cb50e438e5606fe21df19d66944ed4e5739))
* **internal:** minor improvements to csproj and gitignore ([31d0ea1](https://github.com/Alchemyst-ai/alchemyst-sdk-csharp/commit/31d0ea1870879a88b6268ec17a3c07e7a679fd4e))
* **internal:** reduce import qualification ([2331fa7](https://github.com/Alchemyst-ai/alchemyst-sdk-csharp/commit/2331fa7eb643ec37b6904dcdc204fa299c1eee30))
* **internal:** update release please config ([dcd9510](https://github.com/Alchemyst-ai/alchemyst-sdk-csharp/commit/dcd9510a292c0fd8e67d9d6f2fb221a8f4ffe772))
* **internal:** update release please config ([8a796bb](https://github.com/Alchemyst-ai/alchemyst-sdk-csharp/commit/8a796bbd463071a75efad9679550fb1dbbaf0cb3))
* update SDK settings ([71f93b6](https://github.com/Alchemyst-ai/alchemyst-sdk-csharp/commit/71f93b6d8f5ee59268ba1cb011f1cccfc12dfc4e))


### Documentation

* **client:** document `WithOptions` ([6f4b3dc](https://github.com/Alchemyst-ai/alchemyst-sdk-csharp/commit/6f4b3dca881265b1ba3050e0d29562d0fd480bce))
* **client:** document max retries ([350828c](https://github.com/Alchemyst-ai/alchemyst-sdk-csharp/commit/350828c9dc9c67e519e8d66fe63920693d5edbed))
* **client:** document response validation ([cdc68d2](https://github.com/Alchemyst-ai/alchemyst-sdk-csharp/commit/cdc68d225bfce86c15549f9fe44a603d9158d5ca))
* **client:** document timeout option ([ae00582](https://github.com/Alchemyst-ai/alchemyst-sdk-csharp/commit/ae00582574e5d76445e591a895f61b4e7e0ca272))
* **client:** improve snippet formatting ([738aa8f](https://github.com/Alchemyst-ai/alchemyst-sdk-csharp/commit/738aa8f7621caf2e3fc44972caec3f9d5d660111))
* **client:** separate comment content into paragraphs ([fac346b](https://github.com/Alchemyst-ai/alchemyst-sdk-csharp/commit/fac346bb42ffdcb7397f6d753e80fa86c4ab4620))
* **internal:** add warning about implementing interface ([b3d0a8c](https://github.com/Alchemyst-ai/alchemyst-sdk-csharp/commit/b3d0a8c3bc7f81fc94a894e4100d1a7e2bce1839))


### Refactors

* **client:** flatten service namespaces ([2f6b7dd](https://github.com/Alchemyst-ai/alchemyst-sdk-csharp/commit/2f6b7dd76489c3027c18cbfc29b3a13014e203a1))
* **client:** move some defaults out of `ClientOptions` ([48bca16](https://github.com/Alchemyst-ai/alchemyst-sdk-csharp/commit/48bca16639bfd77dcfc5375c4856d1ffe2e7ad52))
* **client:** pass around `ClientOptions` instead of client ([74cda5b](https://github.com/Alchemyst-ai/alchemyst-sdk-csharp/commit/74cda5ba23d8341512ad59fcf6f3fc1b44dfef33))
