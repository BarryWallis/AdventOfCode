using System;

namespace Day2
{
    /*
     * Your flight departs in a few days from the coastal airport; the easiest way down to the coast from here is via toboggan
     * The shopkeeper at the North Pole Toboggan Rental Shop is having a bad day. "Something's wrong with our computers; we 
     * can't log in!" You ask if you can take a look.
     * 
     * Their password database seems to be a little corrupted: some of the passwords wouldn't have been allowed by the Official 
     * Toboggan Corporate Policy that was in effect when they were chosen.
     * 
     * To try to debug the problem, they have created a list (your puzzle input) of passwords (according to the corrupted 
     * database) and the corporate policy when that password was set.
     * 
     * For example, suppose you have the following list:
     * 
     * 1-3 a: abcde
     * 1-3 b: cdefg
     * 2-9 c: ccccccccc
     * 
     * Each line gives the password policy and then the password. The password policy indicates the two positions that must be
     * checked for the given letter. The letter must appear in one of those positions but not the other (all other letters are
     * irrelevant.
     * 
     * How many passwords are valid according to their policies?
     */
    internal class Program
    {
        private static void Main() => Console.WriteLine(PasswordChecker.CheckPasswords(Console.In));
    }
}
