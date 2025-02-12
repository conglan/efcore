﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Microsoft.EntityFrameworkCore.Query;

public class NorthwindStringIncludeQuerySqlServerTest : NorthwindStringIncludeQueryTestBase<
    NorthwindQuerySqlServerFixture<NoopModelCustomizer>>
{
    // ReSharper disable once UnusedParameter.Local
    public NorthwindStringIncludeQuerySqlServerTest(NorthwindQuerySqlServerFixture<NoopModelCustomizer> fixture)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
    }

    public override async Task Include_collection_with_last_no_orderby(bool async)
        => Assert.Equal(
            RelationalStrings.LastUsedWithoutOrderBy(nameof(Enumerable.Last)),
            (await Assert.ThrowsAsync<InvalidOperationException>(
                () => base.Include_collection_with_last_no_orderby(async))).Message);
}
