# DB Insert Speed Tests

Needed to prove which method to insert was faster in our case for a lot of SQL inserts.

We were testing serializing/reflecting objects into sql insert commands vs FastMember's SqlBulkCopy library.


FastMember SqlBulkCopy won at the time by a fair margin.
