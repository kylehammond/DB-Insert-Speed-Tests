namespace DBInsertSpeedTests {

    public class InsertTestType
    {
        [PrimaryKey]
        public int Id { get; set; }
        public int IntProp { get; set; }
        public string StringProp1 { get; set; }
        public string StringProp2 { get; set; }
    }

    public class InsertTestType1 : InsertTestType { }
    public class InsertTestType2 : InsertTestType { }
    public class InsertTestType3 : InsertTestType { }
}