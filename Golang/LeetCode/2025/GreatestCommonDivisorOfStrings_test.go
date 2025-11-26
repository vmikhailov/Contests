package main

import "testing"

func TestGcdOfStrings(t *testing.T) {
	tests := []struct {
		a    string
		b    string
		want string
	}{
		{"ABCABC", "ABC", "ABC"},
		{"ABABAB", "ABAB", "AB"},
		{"LEET", "CODE", ""},
		{"", "ABC", "ABC"},
		{"ABC", "", "ABC"},
		{"", "", ""},
		{"AAAAAA", "AAA", "AAA"},
		{"ABC", "BC", ""},
	}

	for i, tc := range tests {
		t.Run(tc.a+"|"+tc.b, func(t *testing.T) {
			got := gcdOfStrings(tc.a, tc.b)
			if got != tc.want {
				t.Fatalf("case %d: gcdOfStrings(%q, %q) = %q; want %q", i, tc.a, tc.b, got, tc.want)
			}
		})
	}
}
