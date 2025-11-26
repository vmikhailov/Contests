package main

import "testing"

func TestReverseWords(t *testing.T) {
	tests := []struct {
		name string
		in   string
		want string
	}{
		{"simple", "the sky is blue", "blue is sky the"},
		{"leading/trailing spaces", "  hello world  ", "  world hello  "},
		{"multiple internal spaces", "a good   example", "example good   a"},
		{"empty", "", ""},
		{"only spaces", "   ", "   "},
		{"single word", "one", "one"},
		{"unicode", "héllo world", "world héllo"},
		{"ex1", "a good   example", "example good a"},
	}

	for _, tc := range tests {
		t.Run(tc.name, func(t *testing.T) {
			got := reverseWords(tc.in)
			if got != tc.want {
				t.Fatalf("reverseWords(%q) = %q; want %q", tc.in, got, tc.want)
			}
		})
	}
}
