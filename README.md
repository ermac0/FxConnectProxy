# FxConnectProxy
FxConnectProxy is a .NET library which creates a layer between ForexConnect and the client (service consumer).

The main goal of the project is to break the dependency between the client code and ForexConnect (.NET wrapper).  
*ForexConnect exposes read-only objects, which are impossible to test in a simulated or disconnected environment.*

Majority of ForexConnect's functionality is currently reflected in the proxy.

## Structure
FxConnectProxy consists of two main projects:

* **FxConnectProxy** - an abstraction layer which contains interfaces, entities and utility classes.  
All ForexConnect data objects (a.k.a. Rows) have been mirrored, with some of their properties being
replaced by enums for the ease of use.  
This project doesn't have any dependency on ForexConnect. It serves as a foundation for concrete
implementations with unified interface.

* **FxConnectProxy.Proxy** - actual implementation of ForexConnect communication layer. It is fully
dependent on ForexConnect assemblies. Allows connecting to the back-end system.


Additional projects:

* **FxConnectProxy.Samples** - a winforms application that provides examples of using the main projects.  
They should serve as rudimentary and independent bits of code demonstrating certain scenarios.  
Besides examples that use FxConnectProxy.Proxy to interface with the back-end, there's also an example of "fake proxy",
which could be used for back testing or for simulating market conditions.

* **FxConnectProxy.Tests** - unit tests for FxConnectProxy project.  
*Testing of ForexConnect proxy implementation is limited due to the current nature of the underlying client.
As mentioned before, ForexConnect doesn't allow for creation of its objects by consuming code - it only
passes on objects obtained from the back-end during an active session.*


## License
The license is available at <https://raw.githubusercontent.com/ermac0/FxConnectProxy/master/LICENSE>
