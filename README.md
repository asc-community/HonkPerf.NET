# HonkPerf.NET

Collection of performant (but limited in usage) replacements for BCL's types and methods;

## RefLinq

RefLinq is like Linq, but it must be only used within a method, so behaves more limited than `ref` structs. Its benefit - it does not make allocations for enumerators and captured variables (given that you use it properly). Its API does not differ *much* from that of Linq.

Docs coming soon... 
