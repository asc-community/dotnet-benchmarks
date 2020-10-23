[![Discord](https://img.shields.io/discord/642350046213439489?color=orange&label=Discord)](https://discord.gg/YWJEX7a)
[![GitHub](https://img.shields.io/github/license/asc-community/dotnet-benchmarks)](./LICENSE)
![Built by community](https://img.shields.io/badge/Built%20by-Community-blue)

## Benchmark Almanac for .NET

In this repo we are collecting benchmarks for different situations, as well as
some thoughts and articles for developers about improving their software's performance. 
We hope that this project may become a useful reference for people.

### Benchmarks

[![Benchmarks](https://img.shields.io/badge/Go%20to-Benchmarks-blueviolet)](./Benchmarks)

Here you can see all benchmarks collected for the Almanac. The idea
is to consider cases where the developer does not expected a performance issue. The current
public API and the approach programmers follow doesn't let us write a very fast code,
so we have to know all those issues.

Most programmers who care about performance would either look at the JIT's generated
assembler to see where the issues can come from, or write their own benchmarks to
test different cases.

Here we collect all those benchmarks in one repository, which is and will be open for everyone.
Not only that, we highly encourage the community, you including, to try to add your
benchmark too.

To avoid the mess created by so many benchmarks, we started writing pieces of articles
and advices for developers who don't want to spend a day on investigating the benchmarks.

### Articles

[![Articles](https://img.shields.io/badge/Go%20to-Articles-blueviolet)](./Articles)

Benchmarks tell us truth, but one could need a quick tip instead. That's why there are
some articles that may help you to get through these benchmarks.

As anything else on Earth, they may contain mistakes, that is why it might be
safer to rely on benchmarks rather than articles that are based on them. However,
why not to try the tip form the article and see for yourself whether it works or not?

As well as benchmarks, it is highly encouraged to help us with those articles. All the content
from the repo is open and exposed to any healthy contributions.

### Contribution

If you want to add a new benchmark, either create a new folder for it, or add a file to 
an existing one, if your benchmark fits an existing category.

If you want to add an article, just go ahead, so far we don't have any recommendations on it,
we will see how it goes :).

Any other contribution is welcomed as well!
