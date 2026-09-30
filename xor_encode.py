#!/usr/bin/env python3
import os

KEY = [0xDE, 0xAD, 0xBE, 0xEF, 0xCA, 0xFE, 0xBA, 0xBE]

def xor_encode(data: bytes, key: list) -> bytes:
    return bytes([b ^ key[i % len(key)] for i, b in enumerate(data)])

def main():
    print("=== XOR Payload Encoder ===\n")
    print(f"[*] Key: {' '.join(f'{b:02X}' for b in KEY)}\n")

    filepath = input("Enter payload file path: ").strip()

    if not os.path.isfile(filepath):
        print(f"[-] File not found: {filepath}")
        return

    with open(filepath, 'rb') as f:
        data = f.read()

    encoded = xor_encode(data, KEY)

    out_path = os.path.splitext(filepath)[0] + '.enc'
    with open(out_path, 'wb') as f:
        f.write(encoded)

    print(f"\n[+] Input:   {filepath} ({len(data)} bytes)")
    print(f"[+] Output:  {out_path} ({len(encoded)} bytes)")
    print(f"[+] Key:     {' '.join(f'{b:02X}' for b in KEY)}")
    print("\n[*] C array (for loader):")
    print(f"unsigned char key[] = {{ {', '.join(f'0x{b:02X}' for b in KEY)} }};")

if __name__ == "__main__":
    main()
