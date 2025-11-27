package main

import (
	"bytes"
	"testing"
)

func TestCompress(t *testing.T) {
	tests := []struct {
		name string
		in   []byte
		want []byte
	}{
		{"single chars", []byte("abc"), []byte("abc")},
		{"simple repeats", []byte("aabccc"), []byte("a2bc3")},
		{"all same", []byte("aaaa"), []byte("a4")},
		{"empty", []byte(""), []byte("")},
		{"two-digit count", []byte("aaaaaaaaaaa"), []byte("a11")},
	}

	for _, tt := range tests {
		t.Run(tt.name, func(t *testing.T) {
			input := append([]byte(nil), tt.in...)
			n := compress(input) // compress writes the result into input and returns new length
			got := input[:n]
			if !bytes.Equal(got, tt.want) {
				t.Fatalf("compress(%q) = %q (n=%d), want %q", string(tt.in), string(got), n, string(tt.want))
			}
		})
	}
}
