package main

import "testing"

func TestReverseVowels(t *testing.T) {
	tests := []struct {
		in   string
		want string
	}{
		{"hello", "holle"},
		{"leetcode", "leotcede"},
		{"", ""},
		{"a", "a"},
		{"ab", "ab"},
		{"aba", "aba"},
		{"AEIOU", "UOIEA"},
		{"Héllo", "Hóllé"},
		{"世界", "世界"}, // no vowels in these runes
	}

	for _, tc := range tests {
		got := reverseVowels(tc.in)
		if got != tc.want {
			t.Fatalf("reverseVowels(%q) = %q; want %q", tc.in, got, tc.want)
		}
	}
}
