function throwItem(%val)
{
   if (%val)
      commandToServer('Throw', "TestItem");
}
