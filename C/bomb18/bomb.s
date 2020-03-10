
bomb：     文件格式 elf64-x86-64


Disassembly of section .init:

0000000000001000 <_init>:
    1000:	48 83 ec 08          	sub    $0x8,%rsp
    1004:	48 8b 05 dd 3f 00 00 	mov    0x3fdd(%rip),%rax        # 4fe8 <__gmon_start__>
    100b:	48 85 c0             	test   %rax,%rax
    100e:	74 02                	je     1012 <_init+0x12>
    1010:	ff d0                	callq  *%rax
    1012:	48 83 c4 08          	add    $0x8,%rsp
    1016:	c3                   	retq   

Disassembly of section .plt:

0000000000001020 <.plt>:
    1020:	ff 35 da 3e 00 00    	pushq  0x3eda(%rip)        # 4f00 <_GLOBAL_OFFSET_TABLE_+0x8>
    1026:	ff 25 dc 3e 00 00    	jmpq   *0x3edc(%rip)        # 4f08 <_GLOBAL_OFFSET_TABLE_+0x10>
    102c:	0f 1f 40 00          	nopl   0x0(%rax)

0000000000001030 <getenv@plt>:
    1030:	ff 25 da 3e 00 00    	jmpq   *0x3eda(%rip)        # 4f10 <getenv@GLIBC_2.2.5>
    1036:	68 00 00 00 00       	pushq  $0x0
    103b:	e9 e0 ff ff ff       	jmpq   1020 <.plt>

0000000000001040 <__errno_location@plt>:
    1040:	ff 25 d2 3e 00 00    	jmpq   *0x3ed2(%rip)        # 4f18 <__errno_location@GLIBC_2.2.5>
    1046:	68 01 00 00 00       	pushq  $0x1
    104b:	e9 d0 ff ff ff       	jmpq   1020 <.plt>

0000000000001050 <strcpy@plt>:
    1050:	ff 25 ca 3e 00 00    	jmpq   *0x3eca(%rip)        # 4f20 <strcpy@GLIBC_2.2.5>
    1056:	68 02 00 00 00       	pushq  $0x2
    105b:	e9 c0 ff ff ff       	jmpq   1020 <.plt>

0000000000001060 <puts@plt>:
    1060:	ff 25 c2 3e 00 00    	jmpq   *0x3ec2(%rip)        # 4f28 <puts@GLIBC_2.2.5>
    1066:	68 03 00 00 00       	pushq  $0x3
    106b:	e9 b0 ff ff ff       	jmpq   1020 <.plt>

0000000000001070 <write@plt>:
    1070:	ff 25 ba 3e 00 00    	jmpq   *0x3eba(%rip)        # 4f30 <write@GLIBC_2.2.5>
    1076:	68 04 00 00 00       	pushq  $0x4
    107b:	e9 a0 ff ff ff       	jmpq   1020 <.plt>

0000000000001080 <__stack_chk_fail@plt>:
    1080:	ff 25 b2 3e 00 00    	jmpq   *0x3eb2(%rip)        # 4f38 <__stack_chk_fail@GLIBC_2.4>
    1086:	68 05 00 00 00       	pushq  $0x5
    108b:	e9 90 ff ff ff       	jmpq   1020 <.plt>

0000000000001090 <alarm@plt>:
    1090:	ff 25 aa 3e 00 00    	jmpq   *0x3eaa(%rip)        # 4f40 <alarm@GLIBC_2.2.5>
    1096:	68 06 00 00 00       	pushq  $0x6
    109b:	e9 80 ff ff ff       	jmpq   1020 <.plt>

00000000000010a0 <close@plt>:
    10a0:	ff 25 a2 3e 00 00    	jmpq   *0x3ea2(%rip)        # 4f48 <close@GLIBC_2.2.5>
    10a6:	68 07 00 00 00       	pushq  $0x7
    10ab:	e9 70 ff ff ff       	jmpq   1020 <.plt>

00000000000010b0 <read@plt>:
    10b0:	ff 25 9a 3e 00 00    	jmpq   *0x3e9a(%rip)        # 4f50 <read@GLIBC_2.2.5>
    10b6:	68 08 00 00 00       	pushq  $0x8
    10bb:	e9 60 ff ff ff       	jmpq   1020 <.plt>

00000000000010c0 <fgets@plt>:
    10c0:	ff 25 92 3e 00 00    	jmpq   *0x3e92(%rip)        # 4f58 <fgets@GLIBC_2.2.5>
    10c6:	68 09 00 00 00       	pushq  $0x9
    10cb:	e9 50 ff ff ff       	jmpq   1020 <.plt>

00000000000010d0 <signal@plt>:
    10d0:	ff 25 8a 3e 00 00    	jmpq   *0x3e8a(%rip)        # 4f60 <signal@GLIBC_2.2.5>
    10d6:	68 0a 00 00 00       	pushq  $0xa
    10db:	e9 40 ff ff ff       	jmpq   1020 <.plt>

00000000000010e0 <gethostbyname@plt>:
    10e0:	ff 25 82 3e 00 00    	jmpq   *0x3e82(%rip)        # 4f68 <gethostbyname@GLIBC_2.2.5>
    10e6:	68 0b 00 00 00       	pushq  $0xb
    10eb:	e9 30 ff ff ff       	jmpq   1020 <.plt>

00000000000010f0 <__memmove_chk@plt>:
    10f0:	ff 25 7a 3e 00 00    	jmpq   *0x3e7a(%rip)        # 4f70 <__memmove_chk@GLIBC_2.3.4>
    10f6:	68 0c 00 00 00       	pushq  $0xc
    10fb:	e9 20 ff ff ff       	jmpq   1020 <.plt>

0000000000001100 <strtol@plt>:
    1100:	ff 25 72 3e 00 00    	jmpq   *0x3e72(%rip)        # 4f78 <strtol@GLIBC_2.2.5>
    1106:	68 0d 00 00 00       	pushq  $0xd
    110b:	e9 10 ff ff ff       	jmpq   1020 <.plt>

0000000000001110 <fflush@plt>:
    1110:	ff 25 6a 3e 00 00    	jmpq   *0x3e6a(%rip)        # 4f80 <fflush@GLIBC_2.2.5>
    1116:	68 0e 00 00 00       	pushq  $0xe
    111b:	e9 00 ff ff ff       	jmpq   1020 <.plt>

0000000000001120 <__isoc99_sscanf@plt>:
    1120:	ff 25 62 3e 00 00    	jmpq   *0x3e62(%rip)        # 4f88 <__isoc99_sscanf@GLIBC_2.7>
    1126:	68 0f 00 00 00       	pushq  $0xf
    112b:	e9 f0 fe ff ff       	jmpq   1020 <.plt>

0000000000001130 <__printf_chk@plt>:
    1130:	ff 25 5a 3e 00 00    	jmpq   *0x3e5a(%rip)        # 4f90 <__printf_chk@GLIBC_2.3.4>
    1136:	68 10 00 00 00       	pushq  $0x10
    113b:	e9 e0 fe ff ff       	jmpq   1020 <.plt>

0000000000001140 <fopen@plt>:
    1140:	ff 25 52 3e 00 00    	jmpq   *0x3e52(%rip)        # 4f98 <fopen@GLIBC_2.2.5>
    1146:	68 11 00 00 00       	pushq  $0x11
    114b:	e9 d0 fe ff ff       	jmpq   1020 <.plt>

0000000000001150 <exit@plt>:
    1150:	ff 25 4a 3e 00 00    	jmpq   *0x3e4a(%rip)        # 4fa0 <exit@GLIBC_2.2.5>
    1156:	68 12 00 00 00       	pushq  $0x12
    115b:	e9 c0 fe ff ff       	jmpq   1020 <.plt>

0000000000001160 <connect@plt>:
    1160:	ff 25 42 3e 00 00    	jmpq   *0x3e42(%rip)        # 4fa8 <connect@GLIBC_2.2.5>
    1166:	68 13 00 00 00       	pushq  $0x13
    116b:	e9 b0 fe ff ff       	jmpq   1020 <.plt>

0000000000001170 <__fprintf_chk@plt>:
    1170:	ff 25 3a 3e 00 00    	jmpq   *0x3e3a(%rip)        # 4fb0 <__fprintf_chk@GLIBC_2.3.4>
    1176:	68 14 00 00 00       	pushq  $0x14
    117b:	e9 a0 fe ff ff       	jmpq   1020 <.plt>

0000000000001180 <sleep@plt>:
    1180:	ff 25 32 3e 00 00    	jmpq   *0x3e32(%rip)        # 4fb8 <sleep@GLIBC_2.2.5>
    1186:	68 15 00 00 00       	pushq  $0x15
    118b:	e9 90 fe ff ff       	jmpq   1020 <.plt>

0000000000001190 <__ctype_b_loc@plt>:
    1190:	ff 25 2a 3e 00 00    	jmpq   *0x3e2a(%rip)        # 4fc0 <__ctype_b_loc@GLIBC_2.3>
    1196:	68 16 00 00 00       	pushq  $0x16
    119b:	e9 80 fe ff ff       	jmpq   1020 <.plt>

00000000000011a0 <__sprintf_chk@plt>:
    11a0:	ff 25 22 3e 00 00    	jmpq   *0x3e22(%rip)        # 4fc8 <__sprintf_chk@GLIBC_2.3.4>
    11a6:	68 17 00 00 00       	pushq  $0x17
    11ab:	e9 70 fe ff ff       	jmpq   1020 <.plt>

00000000000011b0 <socket@plt>:
    11b0:	ff 25 1a 3e 00 00    	jmpq   *0x3e1a(%rip)        # 4fd0 <socket@GLIBC_2.2.5>
    11b6:	68 18 00 00 00       	pushq  $0x18
    11bb:	e9 60 fe ff ff       	jmpq   1020 <.plt>

Disassembly of section .plt.got:

00000000000011c0 <__cxa_finalize@plt>:
    11c0:	ff 25 32 3e 00 00    	jmpq   *0x3e32(%rip)        # 4ff8 <__cxa_finalize@GLIBC_2.2.5>
    11c6:	66 90                	xchg   %ax,%ax

Disassembly of section .text:

00000000000011d0 <_start>:
    11d0:	31 ed                	xor    %ebp,%ebp
    11d2:	49 89 d1             	mov    %rdx,%r9
    11d5:	5e                   	pop    %rsi
    11d6:	48 89 e2             	mov    %rsp,%rdx
    11d9:	48 83 e4 f0          	and    $0xfffffffffffffff0,%rsp
    11dd:	50                   	push   %rax
    11de:	54                   	push   %rsp
    11df:	4c 8d 05 6a 17 00 00 	lea    0x176a(%rip),%r8        # 2950 <__libc_csu_fini>
    11e6:	48 8d 0d 03 17 00 00 	lea    0x1703(%rip),%rcx        # 28f0 <__libc_csu_init>
    11ed:	48 8d 3d c1 00 00 00 	lea    0xc1(%rip),%rdi        # 12b5 <main>
    11f4:	ff 15 e6 3d 00 00    	callq  *0x3de6(%rip)        # 4fe0 <__libc_start_main@GLIBC_2.2.5>
    11fa:	f4                   	hlt    
    11fb:	0f 1f 44 00 00       	nopl   0x0(%rax,%rax,1)

0000000000001200 <deregister_tm_clones>:
    1200:	48 8d 3d 59 44 00 00 	lea    0x4459(%rip),%rdi        # 5660 <stdout@@GLIBC_2.2.5>
    1207:	48 8d 05 52 44 00 00 	lea    0x4452(%rip),%rax        # 5660 <stdout@@GLIBC_2.2.5>
    120e:	48 39 f8             	cmp    %rdi,%rax
    1211:	74 15                	je     1228 <deregister_tm_clones+0x28>
    1213:	48 8b 05 be 3d 00 00 	mov    0x3dbe(%rip),%rax        # 4fd8 <_ITM_deregisterTMCloneTable>
    121a:	48 85 c0             	test   %rax,%rax
    121d:	74 09                	je     1228 <deregister_tm_clones+0x28>
    121f:	ff e0                	jmpq   *%rax
    1221:	0f 1f 80 00 00 00 00 	nopl   0x0(%rax)
    1228:	c3                   	retq   
    1229:	0f 1f 80 00 00 00 00 	nopl   0x0(%rax)

0000000000001230 <register_tm_clones>:
    1230:	48 8d 3d 29 44 00 00 	lea    0x4429(%rip),%rdi        # 5660 <stdout@@GLIBC_2.2.5>
    1237:	48 8d 35 22 44 00 00 	lea    0x4422(%rip),%rsi        # 5660 <stdout@@GLIBC_2.2.5>
    123e:	48 29 fe             	sub    %rdi,%rsi
    1241:	48 c1 fe 03          	sar    $0x3,%rsi
    1245:	48 89 f0             	mov    %rsi,%rax
    1248:	48 c1 e8 3f          	shr    $0x3f,%rax
    124c:	48 01 c6             	add    %rax,%rsi
    124f:	48 d1 fe             	sar    %rsi
    1252:	74 14                	je     1268 <register_tm_clones+0x38>
    1254:	48 8b 05 95 3d 00 00 	mov    0x3d95(%rip),%rax        # 4ff0 <_ITM_registerTMCloneTable>
    125b:	48 85 c0             	test   %rax,%rax
    125e:	74 08                	je     1268 <register_tm_clones+0x38>
    1260:	ff e0                	jmpq   *%rax
    1262:	66 0f 1f 44 00 00    	nopw   0x0(%rax,%rax,1)
    1268:	c3                   	retq   
    1269:	0f 1f 80 00 00 00 00 	nopl   0x0(%rax)

0000000000001270 <__do_global_dtors_aux>:
    1270:	80 3d 11 44 00 00 00 	cmpb   $0x0,0x4411(%rip)        # 5688 <completed.7963>
    1277:	75 2f                	jne    12a8 <__do_global_dtors_aux+0x38>
    1279:	55                   	push   %rbp
    127a:	48 83 3d 76 3d 00 00 	cmpq   $0x0,0x3d76(%rip)        # 4ff8 <__cxa_finalize@GLIBC_2.2.5>
    1281:	00 
    1282:	48 89 e5             	mov    %rsp,%rbp
    1285:	74 0c                	je     1293 <__do_global_dtors_aux+0x23>
    1287:	48 8b 3d 7a 3d 00 00 	mov    0x3d7a(%rip),%rdi        # 5008 <__dso_handle>
    128e:	e8 2d ff ff ff       	callq  11c0 <__cxa_finalize@plt>
    1293:	e8 68 ff ff ff       	callq  1200 <deregister_tm_clones>
    1298:	c6 05 e9 43 00 00 01 	movb   $0x1,0x43e9(%rip)        # 5688 <completed.7963>
    129f:	5d                   	pop    %rbp
    12a0:	c3                   	retq   
    12a1:	0f 1f 80 00 00 00 00 	nopl   0x0(%rax)
    12a8:	c3                   	retq   
    12a9:	0f 1f 80 00 00 00 00 	nopl   0x0(%rax)

00000000000012b0 <frame_dummy>:
    12b0:	e9 7b ff ff ff       	jmpq   1230 <register_tm_clones>

00000000000012b5 <main>:
    12b5:	53                   	push   %rbx
    12b6:	83 ff 01             	cmp    $0x1,%edi
    12b9:	0f 84 f8 00 00 00    	je     13b7 <main+0x102>
    12bf:	48 89 f3             	mov    %rsi,%rbx
    12c2:	83 ff 02             	cmp    $0x2,%edi
    12c5:	0f 85 21 01 00 00    	jne    13ec <main+0x137>
    12cb:	48 8b 7e 08          	mov    0x8(%rsi),%rdi
    12cf:	48 8d 35 2e 1d 00 00 	lea    0x1d2e(%rip),%rsi        # 3004 <_IO_stdin_used+0x4>
    12d6:	e8 65 fe ff ff       	callq  1140 <fopen@plt>
    12db:	48 89 05 ae 43 00 00 	mov    %rax,0x43ae(%rip)        # 5690 <infile>
    12e2:	48 85 c0             	test   %rax,%rax
    12e5:	0f 84 df 00 00 00    	je     13ca <main+0x115>
    12eb:	e8 36 07 00 00       	callq  1a26 <initialize_bomb>
    12f0:	48 8d 3d 91 1d 00 00 	lea    0x1d91(%rip),%rdi        # 3088 <_IO_stdin_used+0x88>
    12f7:	e8 64 fd ff ff       	callq  1060 <puts@plt>
    12fc:	48 8d 3d c5 1d 00 00 	lea    0x1dc5(%rip),%rdi        # 30c8 <_IO_stdin_used+0xc8>
    1303:	e8 58 fd ff ff       	callq  1060 <puts@plt>
    1308:	e8 24 08 00 00       	callq  1b31 <read_line>
    130d:	48 89 c7             	mov    %rax,%rdi
    1310:	e8 fa 00 00 00       	callq  140f <phase_1>
    1315:	e8 5b 09 00 00       	callq  1c75 <phase_defused>
    131a:	48 8d 3d d7 1d 00 00 	lea    0x1dd7(%rip),%rdi        # 30f8 <_IO_stdin_used+0xf8>
    1321:	e8 3a fd ff ff       	callq  1060 <puts@plt>
    1326:	e8 06 08 00 00       	callq  1b31 <read_line>
    132b:	48 89 c7             	mov    %rax,%rdi
    132e:	e8 fc 00 00 00       	callq  142f <phase_2>
    1333:	e8 3d 09 00 00       	callq  1c75 <phase_defused>
    1338:	48 8d 3d fe 1c 00 00 	lea    0x1cfe(%rip),%rdi        # 303d <_IO_stdin_used+0x3d>
    133f:	e8 1c fd ff ff       	callq  1060 <puts@plt>
    1344:	e8 e8 07 00 00       	callq  1b31 <read_line>
    1349:	48 89 c7             	mov    %rax,%rdi
    134c:	e8 4d 01 00 00       	callq  149e <phase_3>
    1351:	e8 1f 09 00 00       	callq  1c75 <phase_defused>
    1356:	48 8d 3d fe 1c 00 00 	lea    0x1cfe(%rip),%rdi        # 305b <_IO_stdin_used+0x5b>
    135d:	e8 fe fc ff ff       	callq  1060 <puts@plt>
    1362:	e8 ca 07 00 00       	callq  1b31 <read_line>
    1367:	48 89 c7             	mov    %rax,%rdi
    136a:	e8 da 02 00 00       	callq  1649 <phase_4>
    136f:	e8 01 09 00 00       	callq  1c75 <phase_defused>
    1374:	48 8d 3d ad 1d 00 00 	lea    0x1dad(%rip),%rdi        # 3128 <_IO_stdin_used+0x128>
    137b:	e8 e0 fc ff ff       	callq  1060 <puts@plt>
    1380:	e8 ac 07 00 00       	callq  1b31 <read_line>
    1385:	48 89 c7             	mov    %rax,%rdi
    1388:	e8 31 03 00 00       	callq  16be <phase_5>
    138d:	e8 e3 08 00 00       	callq  1c75 <phase_defused>
    1392:	48 8d 3d d1 1c 00 00 	lea    0x1cd1(%rip),%rdi        # 306a <_IO_stdin_used+0x6a>
    1399:	e8 c2 fc ff ff       	callq  1060 <puts@plt>
    139e:	e8 8e 07 00 00       	callq  1b31 <read_line>
    13a3:	48 89 c7             	mov    %rax,%rdi
    13a6:	e8 9d 03 00 00       	callq  1748 <phase_6>
    13ab:	e8 c5 08 00 00       	callq  1c75 <phase_defused>
    13b0:	b8 00 00 00 00       	mov    $0x0,%eax
    13b5:	5b                   	pop    %rbx
    13b6:	c3                   	retq   
    13b7:	48 8b 05 b2 42 00 00 	mov    0x42b2(%rip),%rax        # 5670 <stdin@@GLIBC_2.2.5>
    13be:	48 89 05 cb 42 00 00 	mov    %rax,0x42cb(%rip)        # 5690 <infile>
    13c5:	e9 21 ff ff ff       	jmpq   12eb <main+0x36>
    13ca:	48 8b 4b 08          	mov    0x8(%rbx),%rcx
    13ce:	48 8b 13             	mov    (%rbx),%rdx
    13d1:	48 8d 35 2e 1c 00 00 	lea    0x1c2e(%rip),%rsi        # 3006 <_IO_stdin_used+0x6>
    13d8:	bf 01 00 00 00       	mov    $0x1,%edi
    13dd:	e8 4e fd ff ff       	callq  1130 <__printf_chk@plt>
    13e2:	bf 08 00 00 00       	mov    $0x8,%edi
    13e7:	e8 64 fd ff ff       	callq  1150 <exit@plt>
    13ec:	48 8b 16             	mov    (%rsi),%rdx
    13ef:	48 8d 35 2d 1c 00 00 	lea    0x1c2d(%rip),%rsi        # 3023 <_IO_stdin_used+0x23>
    13f6:	bf 01 00 00 00       	mov    $0x1,%edi
    13fb:	b8 00 00 00 00       	mov    $0x0,%eax
    1400:	e8 2b fd ff ff       	callq  1130 <__printf_chk@plt>
    1405:	bf 08 00 00 00       	mov    $0x8,%edi
    140a:	e8 41 fd ff ff       	callq  1150 <exit@plt>

000000000000140f <phase_1>:
    140f:	48 83 ec 08          	sub    $0x8,%rsp
    1413:	48 8d 35 36 1d 00 00 	lea    0x1d36(%rip),%rsi        # 3150 <_IO_stdin_used+0x150>
    141a:	e8 9f 05 00 00       	callq  19be <strings_not_equal>
    141f:	85 c0                	test   %eax,%eax
    1421:	75 05                	jne    1428 <phase_1+0x19>
    1423:	48 83 c4 08          	add    $0x8,%rsp
    1427:	c3                   	retq   
    1428:	e8 9d 06 00 00       	callq  1aca <explode_bomb>
    142d:	eb f4                	jmp    1423 <phase_1+0x14>

000000000000142f <phase_2>:
    142f:	55                   	push   %rbp
    1430:	53                   	push   %rbx
    1431:	48 83 ec 28          	sub    $0x28,%rsp
    1435:	64 48 8b 04 25 28 00 	mov    %fs:0x28,%rax
    143c:	00 00 
    143e:	48 89 44 24 18       	mov    %rax,0x18(%rsp)
    1443:	31 c0                	xor    %eax,%eax
    1445:	48 89 e6             	mov    %rsp,%rsi
    1448:	e8 a3 06 00 00       	callq  1af0 <read_six_numbers>
    144d:	83 3c 24 00          	cmpl   $0x0,(%rsp)
    1451:	75 07                	jne    145a <phase_2+0x2b>
    1453:	83 7c 24 04 01       	cmpl   $0x1,0x4(%rsp)
    1458:	74 05                	je     145f <phase_2+0x30>
    145a:	e8 6b 06 00 00       	callq  1aca <explode_bomb>
    145f:	48 89 e3             	mov    %rsp,%rbx
    1462:	48 8d 6b 10          	lea    0x10(%rbx),%rbp
    1466:	eb 0e                	jmp    1476 <phase_2+0x47>
    1468:	e8 5d 06 00 00       	callq  1aca <explode_bomb>
    146d:	48 83 c3 04          	add    $0x4,%rbx
    1471:	48 39 eb             	cmp    %rbp,%rbx
    1474:	74 0c                	je     1482 <phase_2+0x53>
    1476:	8b 43 04             	mov    0x4(%rbx),%eax
    1479:	03 03                	add    (%rbx),%eax
    147b:	39 43 08             	cmp    %eax,0x8(%rbx)
    147e:	74 ed                	je     146d <phase_2+0x3e>
    1480:	eb e6                	jmp    1468 <phase_2+0x39>
    1482:	48 8b 44 24 18       	mov    0x18(%rsp),%rax
    1487:	64 48 33 04 25 28 00 	xor    %fs:0x28,%rax
    148e:	00 00 
    1490:	75 07                	jne    1499 <phase_2+0x6a>
    1492:	48 83 c4 28          	add    $0x28,%rsp
    1496:	5b                   	pop    %rbx
    1497:	5d                   	pop    %rbp
    1498:	c3                   	retq   
    1499:	e8 e2 fb ff ff       	callq  1080 <__stack_chk_fail@plt>

000000000000149e <phase_3>:
    149e:	48 83 ec 28          	sub    $0x28,%rsp
    14a2:	64 48 8b 04 25 28 00 	mov    %fs:0x28,%rax
    14a9:	00 00 
    14ab:	48 89 44 24 18       	mov    %rax,0x18(%rsp)
    14b0:	31 c0                	xor    %eax,%eax
    14b2:	48 8d 4c 24 0f       	lea    0xf(%rsp),%rcx
    14b7:	48 8d 54 24 10       	lea    0x10(%rsp),%rdx
    14bc:	4c 8d 44 24 14       	lea    0x14(%rsp),%r8
    14c1:	48 8d 35 ee 1c 00 00 	lea    0x1cee(%rip),%rsi        # 31b6 <_IO_stdin_used+0x1b6>
    14c8:	e8 53 fc ff ff       	callq  1120 <__isoc99_sscanf@plt>
    14cd:	83 f8 02             	cmp    $0x2,%eax
    14d0:	7e 1f                	jle    14f1 <phase_3+0x53>
    14d2:	83 7c 24 10 07       	cmpl   $0x7,0x10(%rsp)
    14d7:	0f 87 09 01 00 00    	ja     15e6 <phase_3+0x148>
    14dd:	8b 44 24 10          	mov    0x10(%rsp),%eax
    14e1:	48 8d 15 e8 1c 00 00 	lea    0x1ce8(%rip),%rdx        # 31d0 <_IO_stdin_used+0x1d0>
    14e8:	48 63 04 82          	movslq (%rdx,%rax,4),%rax
    14ec:	48 01 d0             	add    %rdx,%rax
    14ef:	ff e0                	jmpq   *%rax
    14f1:	e8 d4 05 00 00       	callq  1aca <explode_bomb>
    14f6:	eb da                	jmp    14d2 <phase_3+0x34>
    14f8:	b8 70 00 00 00       	mov    $0x70,%eax
    14fd:	81 7c 24 14 ee 02 00 	cmpl   $0x2ee,0x14(%rsp)
    1504:	00 
    1505:	0f 84 e5 00 00 00    	je     15f0 <phase_3+0x152>
    150b:	e8 ba 05 00 00       	callq  1aca <explode_bomb>
    1510:	b8 70 00 00 00       	mov    $0x70,%eax
    1515:	e9 d6 00 00 00       	jmpq   15f0 <phase_3+0x152>
    151a:	b8 65 00 00 00       	mov    $0x65,%eax
    151f:	83 7c 24 14 3b       	cmpl   $0x3b,0x14(%rsp)
    1524:	0f 84 c6 00 00 00    	je     15f0 <phase_3+0x152>
    152a:	e8 9b 05 00 00       	callq  1aca <explode_bomb>
    152f:	b8 65 00 00 00       	mov    $0x65,%eax
    1534:	e9 b7 00 00 00       	jmpq   15f0 <phase_3+0x152>
    1539:	b8 69 00 00 00       	mov    $0x69,%eax
    153e:	81 7c 24 14 88 02 00 	cmpl   $0x288,0x14(%rsp)
    1545:	00 
    1546:	0f 84 a4 00 00 00    	je     15f0 <phase_3+0x152>
    154c:	e8 79 05 00 00       	callq  1aca <explode_bomb>
    1551:	b8 69 00 00 00       	mov    $0x69,%eax
    1556:	e9 95 00 00 00       	jmpq   15f0 <phase_3+0x152>
    155b:	b8 76 00 00 00       	mov    $0x76,%eax
    1560:	81 7c 24 14 c8 02 00 	cmpl   $0x2c8,0x14(%rsp)
    1567:	00 
    1568:	0f 84 82 00 00 00    	je     15f0 <phase_3+0x152>
    156e:	e8 57 05 00 00       	callq  1aca <explode_bomb>
    1573:	b8 76 00 00 00       	mov    $0x76,%eax
    1578:	eb 76                	jmp    15f0 <phase_3+0x152>
    157a:	b8 74 00 00 00       	mov    $0x74,%eax
    157f:	81 7c 24 14 d0 02 00 	cmpl   $0x2d0,0x14(%rsp)
    1586:	00 
    1587:	74 67                	je     15f0 <phase_3+0x152>
    1589:	e8 3c 05 00 00       	callq  1aca <explode_bomb>
    158e:	b8 74 00 00 00       	mov    $0x74,%eax
    1593:	eb 5b                	jmp    15f0 <phase_3+0x152>
    1595:	b8 62 00 00 00       	mov    $0x62,%eax
    159a:	81 7c 24 14 2a 02 00 	cmpl   $0x22a,0x14(%rsp)
    15a1:	00 
    15a2:	74 4c                	je     15f0 <phase_3+0x152>
    15a4:	e8 21 05 00 00       	callq  1aca <explode_bomb>
    15a9:	b8 62 00 00 00       	mov    $0x62,%eax
    15ae:	eb 40                	jmp    15f0 <phase_3+0x152>
    15b0:	b8 71 00 00 00       	mov    $0x71,%eax
    15b5:	81 7c 24 14 37 02 00 	cmpl   $0x237,0x14(%rsp)
    15bc:	00 
    15bd:	74 31                	je     15f0 <phase_3+0x152>
    15bf:	e8 06 05 00 00       	callq  1aca <explode_bomb>
    15c4:	b8 71 00 00 00       	mov    $0x71,%eax
    15c9:	eb 25                	jmp    15f0 <phase_3+0x152>
    15cb:	b8 74 00 00 00       	mov    $0x74,%eax
    15d0:	81 7c 24 14 6a 01 00 	cmpl   $0x16a,0x14(%rsp)
    15d7:	00 
    15d8:	74 16                	je     15f0 <phase_3+0x152>
    15da:	e8 eb 04 00 00       	callq  1aca <explode_bomb>
    15df:	b8 74 00 00 00       	mov    $0x74,%eax
    15e4:	eb 0a                	jmp    15f0 <phase_3+0x152>
    15e6:	e8 df 04 00 00       	callq  1aca <explode_bomb>
    15eb:	b8 65 00 00 00       	mov    $0x65,%eax
    15f0:	38 44 24 0f          	cmp    %al,0xf(%rsp)
    15f4:	75 15                	jne    160b <phase_3+0x16d>
    15f6:	48 8b 44 24 18       	mov    0x18(%rsp),%rax
    15fb:	64 48 33 04 25 28 00 	xor    %fs:0x28,%rax
    1602:	00 00 
    1604:	75 0c                	jne    1612 <phase_3+0x174>
    1606:	48 83 c4 28          	add    $0x28,%rsp
    160a:	c3                   	retq   
    160b:	e8 ba 04 00 00       	callq  1aca <explode_bomb>
    1610:	eb e4                	jmp    15f6 <phase_3+0x158>
    1612:	e8 69 fa ff ff       	callq  1080 <__stack_chk_fail@plt>

0000000000001617 <func4>:
    1617:	53                   	push   %rbx
    1618:	89 d0                	mov    %edx,%eax
    161a:	29 f0                	sub    %esi,%eax
    161c:	89 c3                	mov    %eax,%ebx
    161e:	c1 eb 1f             	shr    $0x1f,%ebx
    1621:	01 c3                	add    %eax,%ebx
    1623:	d1 fb                	sar    %ebx
    1625:	01 f3                	add    %esi,%ebx
    1627:	39 fb                	cmp    %edi,%ebx
    1629:	7f 06                	jg     1631 <func4+0x1a>
    162b:	7c 10                	jl     163d <func4+0x26>
    162d:	89 d8                	mov    %ebx,%eax
    162f:	5b                   	pop    %rbx
    1630:	c3                   	retq   
    1631:	8d 53 ff             	lea    -0x1(%rbx),%edx
    1634:	e8 de ff ff ff       	callq  1617 <func4>
    1639:	01 c3                	add    %eax,%ebx
    163b:	eb f0                	jmp    162d <func4+0x16>
    163d:	8d 73 01             	lea    0x1(%rbx),%esi
    1640:	e8 d2 ff ff ff       	callq  1617 <func4>
    1645:	01 c3                	add    %eax,%ebx
    1647:	eb e4                	jmp    162d <func4+0x16>

0000000000001649 <phase_4>:
    1649:	48 83 ec 18          	sub    $0x18,%rsp
    164d:	64 48 8b 04 25 28 00 	mov    %fs:0x28,%rax
    1654:	00 00 
    1656:	48 89 44 24 08       	mov    %rax,0x8(%rsp)
    165b:	31 c0                	xor    %eax,%eax
    165d:	48 8d 4c 24 04       	lea    0x4(%rsp),%rcx
    1662:	48 89 e2             	mov    %rsp,%rdx
    1665:	48 8d 35 a3 1c 00 00 	lea    0x1ca3(%rip),%rsi        # 330f <array.3514+0x11f>
    166c:	e8 af fa ff ff       	callq  1120 <__isoc99_sscanf@plt>
    1671:	83 f8 02             	cmp    $0x2,%eax
    1674:	75 06                	jne    167c <phase_4+0x33>
    1676:	83 3c 24 0e          	cmpl   $0xe,(%rsp)
    167a:	76 05                	jbe    1681 <phase_4+0x38>
    167c:	e8 49 04 00 00       	callq  1aca <explode_bomb>
    1681:	ba 0e 00 00 00       	mov    $0xe,%edx
    1686:	be 00 00 00 00       	mov    $0x0,%esi
    168b:	8b 3c 24             	mov    (%rsp),%edi
    168e:	e8 84 ff ff ff       	callq  1617 <func4>
    1693:	83 f8 1f             	cmp    $0x1f,%eax
    1696:	75 07                	jne    169f <phase_4+0x56>
    1698:	83 7c 24 04 1f       	cmpl   $0x1f,0x4(%rsp)
    169d:	74 05                	je     16a4 <phase_4+0x5b>
    169f:	e8 26 04 00 00       	callq  1aca <explode_bomb>
    16a4:	48 8b 44 24 08       	mov    0x8(%rsp),%rax
    16a9:	64 48 33 04 25 28 00 	xor    %fs:0x28,%rax
    16b0:	00 00 
    16b2:	75 05                	jne    16b9 <phase_4+0x70>
    16b4:	48 83 c4 18          	add    $0x18,%rsp
    16b8:	c3                   	retq   
    16b9:	e8 c2 f9 ff ff       	callq  1080 <__stack_chk_fail@plt>

00000000000016be <phase_5>:
    16be:	53                   	push   %rbx
    16bf:	48 83 ec 10          	sub    $0x10,%rsp
    16c3:	48 89 fb             	mov    %rdi,%rbx
    16c6:	64 48 8b 04 25 28 00 	mov    %fs:0x28,%rax
    16cd:	00 00 
    16cf:	48 89 44 24 08       	mov    %rax,0x8(%rsp)
    16d4:	31 c0                	xor    %eax,%eax
    16d6:	e8 c6 02 00 00       	callq  19a1 <string_length>
    16db:	83 f8 06             	cmp    $0x6,%eax
    16de:	75 55                	jne    1735 <phase_5+0x77>
    16e0:	b8 00 00 00 00       	mov    $0x0,%eax
    16e5:	48 8d 0d 04 1b 00 00 	lea    0x1b04(%rip),%rcx        # 31f0 <array.3514>
    16ec:	0f b6 14 03          	movzbl (%rbx,%rax,1),%edx
    16f0:	83 e2 0f             	and    $0xf,%edx
    16f3:	0f b6 14 11          	movzbl (%rcx,%rdx,1),%edx
    16f7:	88 54 04 01          	mov    %dl,0x1(%rsp,%rax,1)
    16fb:	48 83 c0 01          	add    $0x1,%rax
    16ff:	48 83 f8 06          	cmp    $0x6,%rax
    1703:	75 e7                	jne    16ec <phase_5+0x2e>
    1705:	c6 44 24 07 00       	movb   $0x0,0x7(%rsp)
    170a:	48 8d 7c 24 01       	lea    0x1(%rsp),%rdi
    170f:	48 8d 35 a9 1a 00 00 	lea    0x1aa9(%rip),%rsi        # 31bf <_IO_stdin_used+0x1bf>
    1716:	e8 a3 02 00 00       	callq  19be <strings_not_equal>
    171b:	85 c0                	test   %eax,%eax
    171d:	75 1d                	jne    173c <phase_5+0x7e>
    171f:	48 8b 44 24 08       	mov    0x8(%rsp),%rax
    1724:	64 48 33 04 25 28 00 	xor    %fs:0x28,%rax
    172b:	00 00 
    172d:	75 14                	jne    1743 <phase_5+0x85>
    172f:	48 83 c4 10          	add    $0x10,%rsp
    1733:	5b                   	pop    %rbx
    1734:	c3                   	retq   
    1735:	e8 90 03 00 00       	callq  1aca <explode_bomb>
    173a:	eb a4                	jmp    16e0 <phase_5+0x22>
    173c:	e8 89 03 00 00       	callq  1aca <explode_bomb>
    1741:	eb dc                	jmp    171f <phase_5+0x61>
    1743:	e8 38 f9 ff ff       	callq  1080 <__stack_chk_fail@plt>

0000000000001748 <phase_6>:
    1748:	41 57                	push   %r15
    174a:	41 56                	push   %r14
    174c:	41 55                	push   %r13
    174e:	41 54                	push   %r12
    1750:	55                   	push   %rbp
    1751:	53                   	push   %rbx
    1752:	48 83 ec 68          	sub    $0x68,%rsp
    1756:	64 48 8b 04 25 28 00 	mov    %fs:0x28,%rax
    175d:	00 00 
    175f:	48 89 44 24 58       	mov    %rax,0x58(%rsp)
    1764:	31 c0                	xor    %eax,%eax
    1766:	49 89 e6             	mov    %rsp,%r14
    1769:	4c 89 f6             	mov    %r14,%rsi
    176c:	e8 7f 03 00 00       	callq  1af0 <read_six_numbers>
    1771:	4d 89 f4             	mov    %r14,%r12
    1774:	41 bf 01 00 00 00    	mov    $0x1,%r15d
    177a:	49 89 e5             	mov    %rsp,%r13
    177d:	e9 a7 00 00 00       	jmpq   1829 <phase_6+0xe1>
    1782:	e8 43 03 00 00       	callq  1aca <explode_bomb>
    1787:	e9 af 00 00 00       	jmpq   183b <phase_6+0xf3>
    178c:	48 8d 74 24 20       	lea    0x20(%rsp),%rsi
    1791:	49 8d 7c 24 18       	lea    0x18(%r12),%rdi
    1796:	41 8b 0c 24          	mov    (%r12),%ecx
    179a:	b8 01 00 00 00       	mov    $0x1,%eax
    179f:	48 8d 15 6a 3a 00 00 	lea    0x3a6a(%rip),%rdx        # 5210 <node1>
    17a6:	83 f9 01             	cmp    $0x1,%ecx
    17a9:	7e 0b                	jle    17b6 <phase_6+0x6e>
    17ab:	48 8b 52 08          	mov    0x8(%rdx),%rdx
    17af:	83 c0 01             	add    $0x1,%eax
    17b2:	39 c8                	cmp    %ecx,%eax
    17b4:	75 f5                	jne    17ab <phase_6+0x63>
    17b6:	48 89 16             	mov    %rdx,(%rsi)
    17b9:	49 83 c4 04          	add    $0x4,%r12
    17bd:	48 83 c6 08          	add    $0x8,%rsi
    17c1:	4c 39 e7             	cmp    %r12,%rdi
    17c4:	75 d0                	jne    1796 <phase_6+0x4e>
    17c6:	48 8b 5c 24 20       	mov    0x20(%rsp),%rbx
    17cb:	48 8b 44 24 28       	mov    0x28(%rsp),%rax
    17d0:	48 89 43 08          	mov    %rax,0x8(%rbx)
    17d4:	48 8b 54 24 30       	mov    0x30(%rsp),%rdx
    17d9:	48 89 50 08          	mov    %rdx,0x8(%rax)
    17dd:	48 8b 44 24 38       	mov    0x38(%rsp),%rax
    17e2:	48 89 42 08          	mov    %rax,0x8(%rdx)
    17e6:	48 8b 54 24 40       	mov    0x40(%rsp),%rdx
    17eb:	48 89 50 08          	mov    %rdx,0x8(%rax)
    17ef:	48 8b 44 24 48       	mov    0x48(%rsp),%rax
    17f4:	48 89 42 08          	mov    %rax,0x8(%rdx)
    17f8:	48 c7 40 08 00 00 00 	movq   $0x0,0x8(%rax)
    17ff:	00 
    1800:	bd 05 00 00 00       	mov    $0x5,%ebp
    1805:	eb 4c                	jmp    1853 <phase_6+0x10b>
    1807:	e8 be 02 00 00       	callq  1aca <explode_bomb>
    180c:	48 83 c3 01          	add    $0x1,%rbx
    1810:	83 fb 05             	cmp    $0x5,%ebx
    1813:	7f 0c                	jg     1821 <phase_6+0xd9>
    1815:	41 8b 44 9d 00       	mov    0x0(%r13,%rbx,4),%eax
    181a:	39 45 00             	cmp    %eax,0x0(%rbp)
    181d:	75 ed                	jne    180c <phase_6+0xc4>
    181f:	eb e6                	jmp    1807 <phase_6+0xbf>
    1821:	49 83 c7 01          	add    $0x1,%r15
    1825:	49 83 c6 04          	add    $0x4,%r14
    1829:	4c 89 f5             	mov    %r14,%rbp
    182c:	41 8b 06             	mov    (%r14),%eax
    182f:	83 e8 01             	sub    $0x1,%eax
    1832:	83 f8 05             	cmp    $0x5,%eax
    1835:	0f 87 47 ff ff ff    	ja     1782 <phase_6+0x3a>
    183b:	49 83 ff 06          	cmp    $0x6,%r15
    183f:	0f 84 47 ff ff ff    	je     178c <phase_6+0x44>
    1845:	4c 89 fb             	mov    %r15,%rbx
    1848:	eb cb                	jmp    1815 <phase_6+0xcd>
    184a:	48 8b 5b 08          	mov    0x8(%rbx),%rbx
    184e:	83 ed 01             	sub    $0x1,%ebp
    1851:	74 11                	je     1864 <phase_6+0x11c>
    1853:	48 8b 43 08          	mov    0x8(%rbx),%rax
    1857:	8b 00                	mov    (%rax),%eax
    1859:	39 03                	cmp    %eax,(%rbx)
    185b:	7d ed                	jge    184a <phase_6+0x102>
    185d:	e8 68 02 00 00       	callq  1aca <explode_bomb>
    1862:	eb e6                	jmp    184a <phase_6+0x102>
    1864:	48 8b 44 24 58       	mov    0x58(%rsp),%rax
    1869:	64 48 33 04 25 28 00 	xor    %fs:0x28,%rax
    1870:	00 00 
    1872:	75 0f                	jne    1883 <phase_6+0x13b>
    1874:	48 83 c4 68          	add    $0x68,%rsp
    1878:	5b                   	pop    %rbx
    1879:	5d                   	pop    %rbp
    187a:	41 5c                	pop    %r12
    187c:	41 5d                	pop    %r13
    187e:	41 5e                	pop    %r14
    1880:	41 5f                	pop    %r15
    1882:	c3                   	retq   
    1883:	e8 f8 f7 ff ff       	callq  1080 <__stack_chk_fail@plt>

0000000000001888 <fun7>:
    1888:	48 85 ff             	test   %rdi,%rdi
    188b:	74 32                	je     18bf <fun7+0x37>
    188d:	48 83 ec 08          	sub    $0x8,%rsp
    1891:	8b 17                	mov    (%rdi),%edx
    1893:	39 f2                	cmp    %esi,%edx
    1895:	7f 0c                	jg     18a3 <fun7+0x1b>
    1897:	b8 00 00 00 00       	mov    $0x0,%eax
    189c:	75 12                	jne    18b0 <fun7+0x28>
    189e:	48 83 c4 08          	add    $0x8,%rsp
    18a2:	c3                   	retq   
    18a3:	48 8b 7f 08          	mov    0x8(%rdi),%rdi
    18a7:	e8 dc ff ff ff       	callq  1888 <fun7>
    18ac:	01 c0                	add    %eax,%eax
    18ae:	eb ee                	jmp    189e <fun7+0x16>
    18b0:	48 8b 7f 10          	mov    0x10(%rdi),%rdi
    18b4:	e8 cf ff ff ff       	callq  1888 <fun7>
    18b9:	8d 44 00 01          	lea    0x1(%rax,%rax,1),%eax
    18bd:	eb df                	jmp    189e <fun7+0x16>
    18bf:	b8 ff ff ff ff       	mov    $0xffffffff,%eax
    18c4:	c3                   	retq   

00000000000018c5 <secret_phase>:
    18c5:	53                   	push   %rbx
    18c6:	e8 66 02 00 00       	callq  1b31 <read_line>
    18cb:	ba 0a 00 00 00       	mov    $0xa,%edx
    18d0:	be 00 00 00 00       	mov    $0x0,%esi
    18d5:	48 89 c7             	mov    %rax,%rdi
    18d8:	e8 23 f8 ff ff       	callq  1100 <strtol@plt>
    18dd:	48 89 c3             	mov    %rax,%rbx
    18e0:	8d 40 ff             	lea    -0x1(%rax),%eax
    18e3:	3d e8 03 00 00       	cmp    $0x3e8,%eax
    18e8:	77 26                	ja     1910 <secret_phase+0x4b>
    18ea:	89 de                	mov    %ebx,%esi
    18ec:	48 8d 3d 3d 38 00 00 	lea    0x383d(%rip),%rdi        # 5130 <n1>
    18f3:	e8 90 ff ff ff       	callq  1888 <fun7>
    18f8:	83 f8 05             	cmp    $0x5,%eax
    18fb:	75 1a                	jne    1917 <secret_phase+0x52>
    18fd:	48 8d 3d 8c 18 00 00 	lea    0x188c(%rip),%rdi        # 3190 <_IO_stdin_used+0x190>
    1904:	e8 57 f7 ff ff       	callq  1060 <puts@plt>
    1909:	e8 67 03 00 00       	callq  1c75 <phase_defused>
    190e:	5b                   	pop    %rbx
    190f:	c3                   	retq   
    1910:	e8 b5 01 00 00       	callq  1aca <explode_bomb>
    1915:	eb d3                	jmp    18ea <secret_phase+0x25>
    1917:	e8 ae 01 00 00       	callq  1aca <explode_bomb>
    191c:	eb df                	jmp    18fd <secret_phase+0x38>

000000000000191e <sig_handler>:
    191e:	48 83 ec 08          	sub    $0x8,%rsp
    1922:	48 8d 3d d7 18 00 00 	lea    0x18d7(%rip),%rdi        # 3200 <array.3514+0x10>
    1929:	e8 32 f7 ff ff       	callq  1060 <puts@plt>
    192e:	bf 03 00 00 00       	mov    $0x3,%edi
    1933:	e8 48 f8 ff ff       	callq  1180 <sleep@plt>
    1938:	48 8d 35 83 19 00 00 	lea    0x1983(%rip),%rsi        # 32c2 <array.3514+0xd2>
    193f:	bf 01 00 00 00       	mov    $0x1,%edi
    1944:	b8 00 00 00 00       	mov    $0x0,%eax
    1949:	e8 e2 f7 ff ff       	callq  1130 <__printf_chk@plt>
    194e:	48 8b 3d 0b 3d 00 00 	mov    0x3d0b(%rip),%rdi        # 5660 <stdout@@GLIBC_2.2.5>
    1955:	e8 b6 f7 ff ff       	callq  1110 <fflush@plt>
    195a:	bf 01 00 00 00       	mov    $0x1,%edi
    195f:	e8 1c f8 ff ff       	callq  1180 <sleep@plt>
    1964:	48 8d 3d 5f 19 00 00 	lea    0x195f(%rip),%rdi        # 32ca <array.3514+0xda>
    196b:	e8 f0 f6 ff ff       	callq  1060 <puts@plt>
    1970:	bf 10 00 00 00       	mov    $0x10,%edi
    1975:	e8 d6 f7 ff ff       	callq  1150 <exit@plt>

000000000000197a <invalid_phase>:
    197a:	48 83 ec 08          	sub    $0x8,%rsp
    197e:	48 89 fa             	mov    %rdi,%rdx
    1981:	48 8d 35 4a 19 00 00 	lea    0x194a(%rip),%rsi        # 32d2 <array.3514+0xe2>
    1988:	bf 01 00 00 00       	mov    $0x1,%edi
    198d:	b8 00 00 00 00       	mov    $0x0,%eax
    1992:	e8 99 f7 ff ff       	callq  1130 <__printf_chk@plt>
    1997:	bf 08 00 00 00       	mov    $0x8,%edi
    199c:	e8 af f7 ff ff       	callq  1150 <exit@plt>

00000000000019a1 <string_length>:
    19a1:	80 3f 00             	cmpb   $0x0,(%rdi)
    19a4:	74 12                	je     19b8 <string_length+0x17>
    19a6:	b8 00 00 00 00       	mov    $0x0,%eax
    19ab:	48 83 c7 01          	add    $0x1,%rdi
    19af:	83 c0 01             	add    $0x1,%eax
    19b2:	80 3f 00             	cmpb   $0x0,(%rdi)
    19b5:	75 f4                	jne    19ab <string_length+0xa>
    19b7:	c3                   	retq   
    19b8:	b8 00 00 00 00       	mov    $0x0,%eax
    19bd:	c3                   	retq   

00000000000019be <strings_not_equal>:
    19be:	41 54                	push   %r12
    19c0:	55                   	push   %rbp
    19c1:	53                   	push   %rbx
    19c2:	48 89 fb             	mov    %rdi,%rbx
    19c5:	48 89 f5             	mov    %rsi,%rbp
    19c8:	e8 d4 ff ff ff       	callq  19a1 <string_length>
    19cd:	41 89 c4             	mov    %eax,%r12d
    19d0:	48 89 ef             	mov    %rbp,%rdi
    19d3:	e8 c9 ff ff ff       	callq  19a1 <string_length>
    19d8:	ba 01 00 00 00       	mov    $0x1,%edx
    19dd:	41 39 c4             	cmp    %eax,%r12d
    19e0:	75 2f                	jne    1a11 <strings_not_equal+0x53>
    19e2:	0f b6 03             	movzbl (%rbx),%eax
    19e5:	84 c0                	test   %al,%al
    19e7:	74 2f                	je     1a18 <strings_not_equal+0x5a>
    19e9:	3a 45 00             	cmp    0x0(%rbp),%al
    19ec:	75 31                	jne    1a1f <strings_not_equal+0x61>
    19ee:	b8 01 00 00 00       	mov    $0x1,%eax
    19f3:	0f b6 14 03          	movzbl (%rbx,%rax,1),%edx
    19f7:	84 d2                	test   %dl,%dl
    19f9:	74 11                	je     1a0c <strings_not_equal+0x4e>
    19fb:	48 83 c0 01          	add    $0x1,%rax
    19ff:	38 54 05 ff          	cmp    %dl,-0x1(%rbp,%rax,1)
    1a03:	74 ee                	je     19f3 <strings_not_equal+0x35>
    1a05:	ba 01 00 00 00       	mov    $0x1,%edx
    1a0a:	eb 05                	jmp    1a11 <strings_not_equal+0x53>
    1a0c:	ba 00 00 00 00       	mov    $0x0,%edx
    1a11:	89 d0                	mov    %edx,%eax
    1a13:	5b                   	pop    %rbx
    1a14:	5d                   	pop    %rbp
    1a15:	41 5c                	pop    %r12
    1a17:	c3                   	retq   
    1a18:	ba 00 00 00 00       	mov    $0x0,%edx
    1a1d:	eb f2                	jmp    1a11 <strings_not_equal+0x53>
    1a1f:	ba 01 00 00 00       	mov    $0x1,%edx
    1a24:	eb eb                	jmp    1a11 <strings_not_equal+0x53>

0000000000001a26 <initialize_bomb>:
    1a26:	48 83 ec 08          	sub    $0x8,%rsp
    1a2a:	48 8d 35 ed fe ff ff 	lea    -0x113(%rip),%rsi        # 191e <sig_handler>
    1a31:	bf 02 00 00 00       	mov    $0x2,%edi
    1a36:	e8 95 f6 ff ff       	callq  10d0 <signal@plt>
    1a3b:	48 83 c4 08          	add    $0x8,%rsp
    1a3f:	c3                   	retq   

0000000000001a40 <initialize_bomb_solve>:
    1a40:	c3                   	retq   

0000000000001a41 <blank_line>:
    1a41:	55                   	push   %rbp
    1a42:	53                   	push   %rbx
    1a43:	48 83 ec 08          	sub    $0x8,%rsp
    1a47:	48 89 fd             	mov    %rdi,%rbp
    1a4a:	0f b6 5d 00          	movzbl 0x0(%rbp),%ebx
    1a4e:	84 db                	test   %bl,%bl
    1a50:	74 1e                	je     1a70 <blank_line+0x2f>
    1a52:	e8 39 f7 ff ff       	callq  1190 <__ctype_b_loc@plt>
    1a57:	48 83 c5 01          	add    $0x1,%rbp
    1a5b:	48 0f be db          	movsbq %bl,%rbx
    1a5f:	48 8b 00             	mov    (%rax),%rax
    1a62:	f6 44 58 01 20       	testb  $0x20,0x1(%rax,%rbx,2)
    1a67:	75 e1                	jne    1a4a <blank_line+0x9>
    1a69:	b8 00 00 00 00       	mov    $0x0,%eax
    1a6e:	eb 05                	jmp    1a75 <blank_line+0x34>
    1a70:	b8 01 00 00 00       	mov    $0x1,%eax
    1a75:	48 83 c4 08          	add    $0x8,%rsp
    1a79:	5b                   	pop    %rbx
    1a7a:	5d                   	pop    %rbp
    1a7b:	c3                   	retq   

0000000000001a7c <skip>:
    1a7c:	55                   	push   %rbp
    1a7d:	53                   	push   %rbx
    1a7e:	48 83 ec 08          	sub    $0x8,%rsp
    1a82:	48 8d 2d 17 3c 00 00 	lea    0x3c17(%rip),%rbp        # 56a0 <input_strings>
    1a89:	48 63 05 fc 3b 00 00 	movslq 0x3bfc(%rip),%rax        # 568c <num_input_strings>
    1a90:	48 8d 3c 80          	lea    (%rax,%rax,4),%rdi
    1a94:	48 c1 e7 04          	shl    $0x4,%rdi
    1a98:	48 01 ef             	add    %rbp,%rdi
    1a9b:	48 8b 15 ee 3b 00 00 	mov    0x3bee(%rip),%rdx        # 5690 <infile>
    1aa2:	be 50 00 00 00       	mov    $0x50,%esi
    1aa7:	e8 14 f6 ff ff       	callq  10c0 <fgets@plt>
    1aac:	48 89 c3             	mov    %rax,%rbx
    1aaf:	48 85 c0             	test   %rax,%rax
    1ab2:	74 0c                	je     1ac0 <skip+0x44>
    1ab4:	48 89 c7             	mov    %rax,%rdi
    1ab7:	e8 85 ff ff ff       	callq  1a41 <blank_line>
    1abc:	85 c0                	test   %eax,%eax
    1abe:	75 c9                	jne    1a89 <skip+0xd>
    1ac0:	48 89 d8             	mov    %rbx,%rax
    1ac3:	48 83 c4 08          	add    $0x8,%rsp
    1ac7:	5b                   	pop    %rbx
    1ac8:	5d                   	pop    %rbp
    1ac9:	c3                   	retq   

0000000000001aca <explode_bomb>:
    1aca:	48 83 ec 08          	sub    $0x8,%rsp
    1ace:	48 8d 3d 0e 18 00 00 	lea    0x180e(%rip),%rdi        # 32e3 <array.3514+0xf3>
    1ad5:	e8 86 f5 ff ff       	callq  1060 <puts@plt>
    1ada:	48 8d 3d 0b 18 00 00 	lea    0x180b(%rip),%rdi        # 32ec <array.3514+0xfc>
    1ae1:	e8 7a f5 ff ff       	callq  1060 <puts@plt>
    1ae6:	bf 08 00 00 00       	mov    $0x8,%edi
    1aeb:	e8 60 f6 ff ff       	callq  1150 <exit@plt>

0000000000001af0 <read_six_numbers>:
    1af0:	48 83 ec 08          	sub    $0x8,%rsp
    1af4:	48 89 f2             	mov    %rsi,%rdx
    1af7:	48 8d 4e 04          	lea    0x4(%rsi),%rcx
    1afb:	48 8d 46 14          	lea    0x14(%rsi),%rax
    1aff:	50                   	push   %rax
    1b00:	48 8d 46 10          	lea    0x10(%rsi),%rax
    1b04:	50                   	push   %rax
    1b05:	4c 8d 4e 0c          	lea    0xc(%rsi),%r9
    1b09:	4c 8d 46 08          	lea    0x8(%rsi),%r8
    1b0d:	48 8d 35 ef 17 00 00 	lea    0x17ef(%rip),%rsi        # 3303 <array.3514+0x113>
    1b14:	b8 00 00 00 00       	mov    $0x0,%eax
    1b19:	e8 02 f6 ff ff       	callq  1120 <__isoc99_sscanf@plt>
    1b1e:	48 83 c4 10          	add    $0x10,%rsp
    1b22:	83 f8 05             	cmp    $0x5,%eax
    1b25:	7e 05                	jle    1b2c <read_six_numbers+0x3c>
    1b27:	48 83 c4 08          	add    $0x8,%rsp
    1b2b:	c3                   	retq   
    1b2c:	e8 99 ff ff ff       	callq  1aca <explode_bomb>

0000000000001b31 <read_line>:
    1b31:	48 83 ec 08          	sub    $0x8,%rsp
    1b35:	b8 00 00 00 00       	mov    $0x0,%eax
    1b3a:	e8 3d ff ff ff       	callq  1a7c <skip>
    1b3f:	48 85 c0             	test   %rax,%rax
    1b42:	74 6f                	je     1bb3 <read_line+0x82>
    1b44:	8b 35 42 3b 00 00    	mov    0x3b42(%rip),%esi        # 568c <num_input_strings>
    1b4a:	48 63 c6             	movslq %esi,%rax
    1b4d:	48 8d 14 80          	lea    (%rax,%rax,4),%rdx
    1b51:	48 c1 e2 04          	shl    $0x4,%rdx
    1b55:	48 8d 05 44 3b 00 00 	lea    0x3b44(%rip),%rax        # 56a0 <input_strings>
    1b5c:	48 01 c2             	add    %rax,%rdx
    1b5f:	48 c7 c1 ff ff ff ff 	mov    $0xffffffffffffffff,%rcx
    1b66:	b8 00 00 00 00       	mov    $0x0,%eax
    1b6b:	48 89 d7             	mov    %rdx,%rdi
    1b6e:	f2 ae                	repnz scas %es:(%rdi),%al
    1b70:	48 f7 d1             	not    %rcx
    1b73:	48 83 e9 01          	sub    $0x1,%rcx
    1b77:	83 f9 4e             	cmp    $0x4e,%ecx
    1b7a:	0f 8f ab 00 00 00    	jg     1c2b <read_line+0xfa>
    1b80:	83 e9 01             	sub    $0x1,%ecx
    1b83:	48 63 c9             	movslq %ecx,%rcx
    1b86:	48 63 c6             	movslq %esi,%rax
    1b89:	48 8d 04 80          	lea    (%rax,%rax,4),%rax
    1b8d:	48 c1 e0 04          	shl    $0x4,%rax
    1b91:	48 89 c7             	mov    %rax,%rdi
    1b94:	48 8d 05 05 3b 00 00 	lea    0x3b05(%rip),%rax        # 56a0 <input_strings>
    1b9b:	48 01 f8             	add    %rdi,%rax
    1b9e:	c6 04 08 00          	movb   $0x0,(%rax,%rcx,1)
    1ba2:	83 c6 01             	add    $0x1,%esi
    1ba5:	89 35 e1 3a 00 00    	mov    %esi,0x3ae1(%rip)        # 568c <num_input_strings>
    1bab:	48 89 d0             	mov    %rdx,%rax
    1bae:	48 83 c4 08          	add    $0x8,%rsp
    1bb2:	c3                   	retq   
    1bb3:	48 8b 05 b6 3a 00 00 	mov    0x3ab6(%rip),%rax        # 5670 <stdin@@GLIBC_2.2.5>
    1bba:	48 39 05 cf 3a 00 00 	cmp    %rax,0x3acf(%rip)        # 5690 <infile>
    1bc1:	74 1b                	je     1bde <read_line+0xad>
    1bc3:	48 8d 3d 69 17 00 00 	lea    0x1769(%rip),%rdi        # 3333 <array.3514+0x143>
    1bca:	e8 61 f4 ff ff       	callq  1030 <getenv@plt>
    1bcf:	48 85 c0             	test   %rax,%rax
    1bd2:	74 20                	je     1bf4 <read_line+0xc3>
    1bd4:	bf 00 00 00 00       	mov    $0x0,%edi
    1bd9:	e8 72 f5 ff ff       	callq  1150 <exit@plt>
    1bde:	48 8d 3d 30 17 00 00 	lea    0x1730(%rip),%rdi        # 3315 <array.3514+0x125>
    1be5:	e8 76 f4 ff ff       	callq  1060 <puts@plt>
    1bea:	bf 08 00 00 00       	mov    $0x8,%edi
    1bef:	e8 5c f5 ff ff       	callq  1150 <exit@plt>
    1bf4:	48 8b 05 75 3a 00 00 	mov    0x3a75(%rip),%rax        # 5670 <stdin@@GLIBC_2.2.5>
    1bfb:	48 89 05 8e 3a 00 00 	mov    %rax,0x3a8e(%rip)        # 5690 <infile>
    1c02:	b8 00 00 00 00       	mov    $0x0,%eax
    1c07:	e8 70 fe ff ff       	callq  1a7c <skip>
    1c0c:	48 85 c0             	test   %rax,%rax
    1c0f:	0f 85 2f ff ff ff    	jne    1b44 <read_line+0x13>
    1c15:	48 8d 3d f9 16 00 00 	lea    0x16f9(%rip),%rdi        # 3315 <array.3514+0x125>
    1c1c:	e8 3f f4 ff ff       	callq  1060 <puts@plt>
    1c21:	bf 00 00 00 00       	mov    $0x0,%edi
    1c26:	e8 25 f5 ff ff       	callq  1150 <exit@plt>
    1c2b:	48 8d 3d 0c 17 00 00 	lea    0x170c(%rip),%rdi        # 333e <array.3514+0x14e>
    1c32:	e8 29 f4 ff ff       	callq  1060 <puts@plt>
    1c37:	8b 05 4f 3a 00 00    	mov    0x3a4f(%rip),%eax        # 568c <num_input_strings>
    1c3d:	8d 50 01             	lea    0x1(%rax),%edx
    1c40:	89 15 46 3a 00 00    	mov    %edx,0x3a46(%rip)        # 568c <num_input_strings>
    1c46:	48 98                	cltq   
    1c48:	48 6b c0 50          	imul   $0x50,%rax,%rax
    1c4c:	48 8d 15 4d 3a 00 00 	lea    0x3a4d(%rip),%rdx        # 56a0 <input_strings>
    1c53:	48 be 2a 2a 2a 74 72 	movabs $0x636e7572742a2a2a,%rsi
    1c5a:	75 6e 63 
    1c5d:	48 bf 61 74 65 64 2a 	movabs $0x2a2a2a64657461,%rdi
    1c64:	2a 2a 00 
    1c67:	48 89 34 02          	mov    %rsi,(%rdx,%rax,1)
    1c6b:	48 89 7c 02 08       	mov    %rdi,0x8(%rdx,%rax,1)
    1c70:	e8 55 fe ff ff       	callq  1aca <explode_bomb>

0000000000001c75 <phase_defused>:
    1c75:	48 83 ec 78          	sub    $0x78,%rsp
    1c79:	64 48 8b 04 25 28 00 	mov    %fs:0x28,%rax
    1c80:	00 00 
    1c82:	48 89 44 24 68       	mov    %rax,0x68(%rsp)
    1c87:	31 c0                	xor    %eax,%eax
    1c89:	83 3d fc 39 00 00 06 	cmpl   $0x6,0x39fc(%rip)        # 568c <num_input_strings>
    1c90:	74 15                	je     1ca7 <phase_defused+0x32>
    1c92:	48 8b 44 24 68       	mov    0x68(%rsp),%rax
    1c97:	64 48 33 04 25 28 00 	xor    %fs:0x28,%rax
    1c9e:	00 00 
    1ca0:	75 73                	jne    1d15 <phase_defused+0xa0>
    1ca2:	48 83 c4 78          	add    $0x78,%rsp
    1ca6:	c3                   	retq   
    1ca7:	48 8d 4c 24 0c       	lea    0xc(%rsp),%rcx
    1cac:	48 8d 54 24 08       	lea    0x8(%rsp),%rdx
    1cb1:	4c 8d 44 24 10       	lea    0x10(%rsp),%r8
    1cb6:	48 8d 35 9c 16 00 00 	lea    0x169c(%rip),%rsi        # 3359 <array.3514+0x169>
    1cbd:	48 8d 3d cc 3a 00 00 	lea    0x3acc(%rip),%rdi        # 5790 <input_strings+0xf0>
    1cc4:	e8 57 f4 ff ff       	callq  1120 <__isoc99_sscanf@plt>
    1cc9:	83 f8 03             	cmp    $0x3,%eax
    1ccc:	74 0e                	je     1cdc <phase_defused+0x67>
    1cce:	48 8d 3d c3 15 00 00 	lea    0x15c3(%rip),%rdi        # 3298 <array.3514+0xa8>
    1cd5:	e8 86 f3 ff ff       	callq  1060 <puts@plt>
    1cda:	eb b6                	jmp    1c92 <phase_defused+0x1d>
    1cdc:	48 8d 7c 24 10       	lea    0x10(%rsp),%rdi
    1ce1:	48 8d 35 7a 16 00 00 	lea    0x167a(%rip),%rsi        # 3362 <array.3514+0x172>
    1ce8:	e8 d1 fc ff ff       	callq  19be <strings_not_equal>
    1ced:	85 c0                	test   %eax,%eax
    1cef:	75 dd                	jne    1cce <phase_defused+0x59>
    1cf1:	48 8d 3d 40 15 00 00 	lea    0x1540(%rip),%rdi        # 3238 <array.3514+0x48>
    1cf8:	e8 63 f3 ff ff       	callq  1060 <puts@plt>
    1cfd:	48 8d 3d 5c 15 00 00 	lea    0x155c(%rip),%rdi        # 3260 <array.3514+0x70>
    1d04:	e8 57 f3 ff ff       	callq  1060 <puts@plt>
    1d09:	b8 00 00 00 00       	mov    $0x0,%eax
    1d0e:	e8 b2 fb ff ff       	callq  18c5 <secret_phase>
    1d13:	eb b9                	jmp    1cce <phase_defused+0x59>
    1d15:	e8 66 f3 ff ff       	callq  1080 <__stack_chk_fail@plt>

0000000000001d1a <sigalrm_handler>:
    1d1a:	48 83 ec 08          	sub    $0x8,%rsp
    1d1e:	b9 00 00 00 00       	mov    $0x0,%ecx
    1d23:	48 8d 15 a6 16 00 00 	lea    0x16a6(%rip),%rdx        # 33d0 <array.3514+0x1e0>
    1d2a:	be 01 00 00 00       	mov    $0x1,%esi
    1d2f:	48 8b 3d 4a 39 00 00 	mov    0x394a(%rip),%rdi        # 5680 <stderr@@GLIBC_2.2.5>
    1d36:	b8 00 00 00 00       	mov    $0x0,%eax
    1d3b:	e8 30 f4 ff ff       	callq  1170 <__fprintf_chk@plt>
    1d40:	bf 01 00 00 00       	mov    $0x1,%edi
    1d45:	e8 06 f4 ff ff       	callq  1150 <exit@plt>

0000000000001d4a <rio_readlineb>:
    1d4a:	41 56                	push   %r14
    1d4c:	41 55                	push   %r13
    1d4e:	41 54                	push   %r12
    1d50:	55                   	push   %rbp
    1d51:	53                   	push   %rbx
    1d52:	48 89 f5             	mov    %rsi,%rbp
    1d55:	48 83 fa 01          	cmp    $0x1,%rdx
    1d59:	0f 86 9d 00 00 00    	jbe    1dfc <rio_readlineb+0xb2>
    1d5f:	48 89 fb             	mov    %rdi,%rbx
    1d62:	4c 8d 74 16 ff       	lea    -0x1(%rsi,%rdx,1),%r14
    1d67:	41 bd 01 00 00 00    	mov    $0x1,%r13d
    1d6d:	4c 8d 67 10          	lea    0x10(%rdi),%r12
    1d71:	eb 17                	jmp    1d8a <rio_readlineb+0x40>
    1d73:	e8 c8 f2 ff ff       	callq  1040 <__errno_location@plt>
    1d78:	83 38 04             	cmpl   $0x4,(%rax)
    1d7b:	74 0d                	je     1d8a <rio_readlineb+0x40>
    1d7d:	48 c7 c0 ff ff ff ff 	mov    $0xffffffffffffffff,%rax
    1d84:	eb 28                	jmp    1dae <rio_readlineb+0x64>
    1d86:	4c 89 63 08          	mov    %r12,0x8(%rbx)
    1d8a:	8b 43 04             	mov    0x4(%rbx),%eax
    1d8d:	85 c0                	test   %eax,%eax
    1d8f:	7f 2e                	jg     1dbf <rio_readlineb+0x75>
    1d91:	ba 00 20 00 00       	mov    $0x2000,%edx
    1d96:	4c 89 e6             	mov    %r12,%rsi
    1d99:	8b 3b                	mov    (%rbx),%edi
    1d9b:	e8 10 f3 ff ff       	callq  10b0 <read@plt>
    1da0:	89 43 04             	mov    %eax,0x4(%rbx)
    1da3:	85 c0                	test   %eax,%eax
    1da5:	78 cc                	js     1d73 <rio_readlineb+0x29>
    1da7:	75 dd                	jne    1d86 <rio_readlineb+0x3c>
    1da9:	b8 00 00 00 00       	mov    $0x0,%eax
    1dae:	85 c0                	test   %eax,%eax
    1db0:	75 52                	jne    1e04 <rio_readlineb+0xba>
    1db2:	b8 00 00 00 00       	mov    $0x0,%eax
    1db7:	41 83 fd 01          	cmp    $0x1,%r13d
    1dbb:	75 2f                	jne    1dec <rio_readlineb+0xa2>
    1dbd:	eb 34                	jmp    1df3 <rio_readlineb+0xa9>
    1dbf:	48 8b 53 08          	mov    0x8(%rbx),%rdx
    1dc3:	0f b6 0a             	movzbl (%rdx),%ecx
    1dc6:	48 83 c2 01          	add    $0x1,%rdx
    1dca:	48 89 53 08          	mov    %rdx,0x8(%rbx)
    1dce:	83 e8 01             	sub    $0x1,%eax
    1dd1:	89 43 04             	mov    %eax,0x4(%rbx)
    1dd4:	48 83 c5 01          	add    $0x1,%rbp
    1dd8:	88 4d ff             	mov    %cl,-0x1(%rbp)
    1ddb:	80 f9 0a             	cmp    $0xa,%cl
    1dde:	74 0c                	je     1dec <rio_readlineb+0xa2>
    1de0:	41 83 c5 01          	add    $0x1,%r13d
    1de4:	4c 39 f5             	cmp    %r14,%rbp
    1de7:	75 a1                	jne    1d8a <rio_readlineb+0x40>
    1de9:	4c 89 f5             	mov    %r14,%rbp
    1dec:	c6 45 00 00          	movb   $0x0,0x0(%rbp)
    1df0:	49 63 c5             	movslq %r13d,%rax
    1df3:	5b                   	pop    %rbx
    1df4:	5d                   	pop    %rbp
    1df5:	41 5c                	pop    %r12
    1df7:	41 5d                	pop    %r13
    1df9:	41 5e                	pop    %r14
    1dfb:	c3                   	retq   
    1dfc:	41 bd 01 00 00 00    	mov    $0x1,%r13d
    1e02:	eb e8                	jmp    1dec <rio_readlineb+0xa2>
    1e04:	48 c7 c0 ff ff ff ff 	mov    $0xffffffffffffffff,%rax
    1e0b:	eb e6                	jmp    1df3 <rio_readlineb+0xa9>

0000000000001e0d <submitr>:
    1e0d:	41 57                	push   %r15
    1e0f:	41 56                	push   %r14
    1e11:	41 55                	push   %r13
    1e13:	41 54                	push   %r12
    1e15:	55                   	push   %rbp
    1e16:	53                   	push   %rbx
    1e17:	48 81 ec 78 a0 00 00 	sub    $0xa078,%rsp
    1e1e:	49 89 fd             	mov    %rdi,%r13
    1e21:	89 f5                	mov    %esi,%ebp
    1e23:	48 89 54 24 08       	mov    %rdx,0x8(%rsp)
    1e28:	48 89 4c 24 10       	mov    %rcx,0x10(%rsp)
    1e2d:	4c 89 44 24 20       	mov    %r8,0x20(%rsp)
    1e32:	4c 89 4c 24 18       	mov    %r9,0x18(%rsp)
    1e37:	48 8b 9c 24 b0 a0 00 	mov    0xa0b0(%rsp),%rbx
    1e3e:	00 
    1e3f:	4c 8b bc 24 b8 a0 00 	mov    0xa0b8(%rsp),%r15
    1e46:	00 
    1e47:	64 48 8b 04 25 28 00 	mov    %fs:0x28,%rax
    1e4e:	00 00 
    1e50:	48 89 84 24 68 a0 00 	mov    %rax,0xa068(%rsp)
    1e57:	00 
    1e58:	31 c0                	xor    %eax,%eax
    1e5a:	c7 44 24 3c 00 00 00 	movl   $0x0,0x3c(%rsp)
    1e61:	00 
    1e62:	ba 00 00 00 00       	mov    $0x0,%edx
    1e67:	be 01 00 00 00       	mov    $0x1,%esi
    1e6c:	bf 02 00 00 00       	mov    $0x2,%edi
    1e71:	e8 3a f3 ff ff       	callq  11b0 <socket@plt>
    1e76:	85 c0                	test   %eax,%eax
    1e78:	0f 88 35 01 00 00    	js     1fb3 <submitr+0x1a6>
    1e7e:	41 89 c4             	mov    %eax,%r12d
    1e81:	4c 89 ef             	mov    %r13,%rdi
    1e84:	e8 57 f2 ff ff       	callq  10e0 <gethostbyname@plt>
    1e89:	48 85 c0             	test   %rax,%rax
    1e8c:	0f 84 71 01 00 00    	je     2003 <submitr+0x1f6>
    1e92:	4c 8d 6c 24 40       	lea    0x40(%rsp),%r13
    1e97:	48 c7 44 24 42 00 00 	movq   $0x0,0x42(%rsp)
    1e9e:	00 00 
    1ea0:	c7 44 24 4a 00 00 00 	movl   $0x0,0x4a(%rsp)
    1ea7:	00 
    1ea8:	66 c7 44 24 4e 00 00 	movw   $0x0,0x4e(%rsp)
    1eaf:	66 c7 44 24 40 02 00 	movw   $0x2,0x40(%rsp)
    1eb6:	48 63 50 14          	movslq 0x14(%rax),%rdx
    1eba:	48 8b 40 18          	mov    0x18(%rax),%rax
    1ebe:	48 8d 7c 24 44       	lea    0x44(%rsp),%rdi
    1ec3:	b9 0c 00 00 00       	mov    $0xc,%ecx
    1ec8:	48 8b 30             	mov    (%rax),%rsi
    1ecb:	e8 20 f2 ff ff       	callq  10f0 <__memmove_chk@plt>
    1ed0:	66 c1 c5 08          	rol    $0x8,%bp
    1ed4:	66 89 6c 24 42       	mov    %bp,0x42(%rsp)
    1ed9:	ba 10 00 00 00       	mov    $0x10,%edx
    1ede:	4c 89 ee             	mov    %r13,%rsi
    1ee1:	44 89 e7             	mov    %r12d,%edi
    1ee4:	e8 77 f2 ff ff       	callq  1160 <connect@plt>
    1ee9:	85 c0                	test   %eax,%eax
    1eeb:	0f 88 7d 01 00 00    	js     206e <submitr+0x261>
    1ef1:	49 c7 c1 ff ff ff ff 	mov    $0xffffffffffffffff,%r9
    1ef8:	b8 00 00 00 00       	mov    $0x0,%eax
    1efd:	4c 89 c9             	mov    %r9,%rcx
    1f00:	48 89 df             	mov    %rbx,%rdi
    1f03:	f2 ae                	repnz scas %es:(%rdi),%al
    1f05:	48 89 ce             	mov    %rcx,%rsi
    1f08:	48 f7 d6             	not    %rsi
    1f0b:	4c 89 c9             	mov    %r9,%rcx
    1f0e:	48 8b 7c 24 08       	mov    0x8(%rsp),%rdi
    1f13:	f2 ae                	repnz scas %es:(%rdi),%al
    1f15:	49 89 c8             	mov    %rcx,%r8
    1f18:	4c 89 c9             	mov    %r9,%rcx
    1f1b:	48 8b 7c 24 10       	mov    0x10(%rsp),%rdi
    1f20:	f2 ae                	repnz scas %es:(%rdi),%al
    1f22:	48 89 ca             	mov    %rcx,%rdx
    1f25:	48 f7 d2             	not    %rdx
    1f28:	4c 89 c9             	mov    %r9,%rcx
    1f2b:	48 8b 7c 24 18       	mov    0x18(%rsp),%rdi
    1f30:	f2 ae                	repnz scas %es:(%rdi),%al
    1f32:	4c 29 c2             	sub    %r8,%rdx
    1f35:	48 29 ca             	sub    %rcx,%rdx
    1f38:	48 8d 44 76 fd       	lea    -0x3(%rsi,%rsi,2),%rax
    1f3d:	48 8d 44 02 7b       	lea    0x7b(%rdx,%rax,1),%rax
    1f42:	48 3d 00 20 00 00    	cmp    $0x2000,%rax
    1f48:	0f 87 7d 01 00 00    	ja     20cb <submitr+0x2be>
    1f4e:	48 8d 94 24 60 40 00 	lea    0x4060(%rsp),%rdx
    1f55:	00 
    1f56:	b9 00 04 00 00       	mov    $0x400,%ecx
    1f5b:	b8 00 00 00 00       	mov    $0x0,%eax
    1f60:	48 89 d7             	mov    %rdx,%rdi
    1f63:	f3 48 ab             	rep stos %rax,%es:(%rdi)
    1f66:	48 c7 c1 ff ff ff ff 	mov    $0xffffffffffffffff,%rcx
    1f6d:	48 89 df             	mov    %rbx,%rdi
    1f70:	f2 ae                	repnz scas %es:(%rdi),%al
    1f72:	48 89 ca             	mov    %rcx,%rdx
    1f75:	48 f7 d2             	not    %rdx
    1f78:	48 89 d1             	mov    %rdx,%rcx
    1f7b:	48 83 e9 01          	sub    $0x1,%rcx
    1f7f:	85 c9                	test   %ecx,%ecx
    1f81:	0f 84 17 05 00 00    	je     249e <submitr+0x691>
    1f87:	8d 41 ff             	lea    -0x1(%rcx),%eax
    1f8a:	4c 8d 74 03 01       	lea    0x1(%rbx,%rax,1),%r14
    1f8f:	48 8d ac 24 60 40 00 	lea    0x4060(%rsp),%rbp
    1f96:	00 
    1f97:	48 8d 84 24 60 80 00 	lea    0x8060(%rsp),%rax
    1f9e:	00 
    1f9f:	48 89 44 24 28       	mov    %rax,0x28(%rsp)
    1fa4:	49 bd d9 ff 00 00 00 	movabs $0x2000000000ffd9,%r13
    1fab:	00 20 00 
    1fae:	e9 a6 01 00 00       	jmpq   2159 <submitr+0x34c>
    1fb3:	48 b8 45 72 72 6f 72 	movabs $0x43203a726f727245,%rax
    1fba:	3a 20 43 
    1fbd:	48 ba 6c 69 65 6e 74 	movabs $0x6e7520746e65696c,%rdx
    1fc4:	20 75 6e 
    1fc7:	49 89 07             	mov    %rax,(%r15)
    1fca:	49 89 57 08          	mov    %rdx,0x8(%r15)
    1fce:	48 b8 61 62 6c 65 20 	movabs $0x206f7420656c6261,%rax
    1fd5:	74 6f 20 
    1fd8:	48 ba 63 72 65 61 74 	movabs $0x7320657461657263,%rdx
    1fdf:	65 20 73 
    1fe2:	49 89 47 10          	mov    %rax,0x10(%r15)
    1fe6:	49 89 57 18          	mov    %rdx,0x18(%r15)
    1fea:	41 c7 47 20 6f 63 6b 	movl   $0x656b636f,0x20(%r15)
    1ff1:	65 
    1ff2:	66 41 c7 47 24 74 00 	movw   $0x74,0x24(%r15)
    1ff9:	b8 ff ff ff ff       	mov    $0xffffffff,%eax
    1ffe:	e9 13 03 00 00       	jmpq   2316 <submitr+0x509>
    2003:	48 b8 45 72 72 6f 72 	movabs $0x44203a726f727245,%rax
    200a:	3a 20 44 
    200d:	48 ba 4e 53 20 69 73 	movabs $0x6e7520736920534e,%rdx
    2014:	20 75 6e 
    2017:	49 89 07             	mov    %rax,(%r15)
    201a:	49 89 57 08          	mov    %rdx,0x8(%r15)
    201e:	48 b8 61 62 6c 65 20 	movabs $0x206f7420656c6261,%rax
    2025:	74 6f 20 
    2028:	48 ba 72 65 73 6f 6c 	movabs $0x2065766c6f736572,%rdx
    202f:	76 65 20 
    2032:	49 89 47 10          	mov    %rax,0x10(%r15)
    2036:	49 89 57 18          	mov    %rdx,0x18(%r15)
    203a:	48 b8 73 65 72 76 65 	movabs $0x6120726576726573,%rax
    2041:	72 20 61 
    2044:	49 89 47 20          	mov    %rax,0x20(%r15)
    2048:	41 c7 47 28 64 64 72 	movl   $0x65726464,0x28(%r15)
    204f:	65 
    2050:	66 41 c7 47 2c 73 73 	movw   $0x7373,0x2c(%r15)
    2057:	41 c6 47 2e 00       	movb   $0x0,0x2e(%r15)
    205c:	44 89 e7             	mov    %r12d,%edi
    205f:	e8 3c f0 ff ff       	callq  10a0 <close@plt>
    2064:	b8 ff ff ff ff       	mov    $0xffffffff,%eax
    2069:	e9 a8 02 00 00       	jmpq   2316 <submitr+0x509>
    206e:	48 b8 45 72 72 6f 72 	movabs $0x55203a726f727245,%rax
    2075:	3a 20 55 
    2078:	48 ba 6e 61 62 6c 65 	movabs $0x6f7420656c62616e,%rdx
    207f:	20 74 6f 
    2082:	49 89 07             	mov    %rax,(%r15)
    2085:	49 89 57 08          	mov    %rdx,0x8(%r15)
    2089:	48 b8 20 63 6f 6e 6e 	movabs $0x7463656e6e6f6320,%rax
    2090:	65 63 74 
    2093:	48 ba 20 74 6f 20 74 	movabs $0x20656874206f7420,%rdx
    209a:	68 65 20 
    209d:	49 89 47 10          	mov    %rax,0x10(%r15)
    20a1:	49 89 57 18          	mov    %rdx,0x18(%r15)
    20a5:	41 c7 47 20 73 65 72 	movl   $0x76726573,0x20(%r15)
    20ac:	76 
    20ad:	66 41 c7 47 24 65 72 	movw   $0x7265,0x24(%r15)
    20b4:	41 c6 47 26 00       	movb   $0x0,0x26(%r15)
    20b9:	44 89 e7             	mov    %r12d,%edi
    20bc:	e8 df ef ff ff       	callq  10a0 <close@plt>
    20c1:	b8 ff ff ff ff       	mov    $0xffffffff,%eax
    20c6:	e9 4b 02 00 00       	jmpq   2316 <submitr+0x509>
    20cb:	48 b8 45 72 72 6f 72 	movabs $0x52203a726f727245,%rax
    20d2:	3a 20 52 
    20d5:	48 ba 65 73 75 6c 74 	movabs $0x747320746c757365,%rdx
    20dc:	20 73 74 
    20df:	49 89 07             	mov    %rax,(%r15)
    20e2:	49 89 57 08          	mov    %rdx,0x8(%r15)
    20e6:	48 b8 72 69 6e 67 20 	movabs $0x6f6f7420676e6972,%rax
    20ed:	74 6f 6f 
    20f0:	48 ba 20 6c 61 72 67 	movabs $0x202e656772616c20,%rdx
    20f7:	65 2e 20 
    20fa:	49 89 47 10          	mov    %rax,0x10(%r15)
    20fe:	49 89 57 18          	mov    %rdx,0x18(%r15)
    2102:	48 b8 49 6e 63 72 65 	movabs $0x6573616572636e49,%rax
    2109:	61 73 65 
    210c:	48 ba 20 53 55 42 4d 	movabs $0x5254494d42555320,%rdx
    2113:	49 54 52 
    2116:	49 89 47 20          	mov    %rax,0x20(%r15)
    211a:	49 89 57 28          	mov    %rdx,0x28(%r15)
    211e:	48 b8 5f 4d 41 58 42 	movabs $0x46554258414d5f,%rax
    2125:	55 46 00 
    2128:	49 89 47 30          	mov    %rax,0x30(%r15)
    212c:	44 89 e7             	mov    %r12d,%edi
    212f:	e8 6c ef ff ff       	callq  10a0 <close@plt>
    2134:	b8 ff ff ff ff       	mov    $0xffffffff,%eax
    2139:	e9 d8 01 00 00       	jmpq   2316 <submitr+0x509>
    213e:	49 0f a3 c5          	bt     %rax,%r13
    2142:	73 21                	jae    2165 <submitr+0x358>
    2144:	44 88 45 00          	mov    %r8b,0x0(%rbp)
    2148:	48 8d 6d 01          	lea    0x1(%rbp),%rbp
    214c:	48 83 c3 01          	add    $0x1,%rbx
    2150:	4c 39 f3             	cmp    %r14,%rbx
    2153:	0f 84 45 03 00 00    	je     249e <submitr+0x691>
    2159:	44 0f b6 03          	movzbl (%rbx),%r8d
    215d:	41 8d 40 d6          	lea    -0x2a(%r8),%eax
    2161:	3c 35                	cmp    $0x35,%al
    2163:	76 d9                	jbe    213e <submitr+0x331>
    2165:	44 89 c0             	mov    %r8d,%eax
    2168:	83 e0 df             	and    $0xffffffdf,%eax
    216b:	83 e8 41             	sub    $0x41,%eax
    216e:	3c 19                	cmp    $0x19,%al
    2170:	76 d2                	jbe    2144 <submitr+0x337>
    2172:	41 80 f8 20          	cmp    $0x20,%r8b
    2176:	74 60                	je     21d8 <submitr+0x3cb>
    2178:	41 8d 40 e0          	lea    -0x20(%r8),%eax
    217c:	3c 5f                	cmp    $0x5f,%al
    217e:	76 0a                	jbe    218a <submitr+0x37d>
    2180:	41 80 f8 09          	cmp    $0x9,%r8b
    2184:	0f 85 87 02 00 00    	jne    2411 <submitr+0x604>
    218a:	45 0f b6 c0          	movzbl %r8b,%r8d
    218e:	48 8d 0d 13 13 00 00 	lea    0x1313(%rip),%rcx        # 34a8 <array.3514+0x2b8>
    2195:	ba 08 00 00 00       	mov    $0x8,%edx
    219a:	be 01 00 00 00       	mov    $0x1,%esi
    219f:	48 8b 7c 24 28       	mov    0x28(%rsp),%rdi
    21a4:	b8 00 00 00 00       	mov    $0x0,%eax
    21a9:	e8 f2 ef ff ff       	callq  11a0 <__sprintf_chk@plt>
    21ae:	0f b6 84 24 60 80 00 	movzbl 0x8060(%rsp),%eax
    21b5:	00 
    21b6:	88 45 00             	mov    %al,0x0(%rbp)
    21b9:	0f b6 84 24 61 80 00 	movzbl 0x8061(%rsp),%eax
    21c0:	00 
    21c1:	88 45 01             	mov    %al,0x1(%rbp)
    21c4:	0f b6 84 24 62 80 00 	movzbl 0x8062(%rsp),%eax
    21cb:	00 
    21cc:	88 45 02             	mov    %al,0x2(%rbp)
    21cf:	48 8d 6d 03          	lea    0x3(%rbp),%rbp
    21d3:	e9 74 ff ff ff       	jmpq   214c <submitr+0x33f>
    21d8:	c6 45 00 2b          	movb   $0x2b,0x0(%rbp)
    21dc:	48 8d 6d 01          	lea    0x1(%rbp),%rbp
    21e0:	e9 67 ff ff ff       	jmpq   214c <submitr+0x33f>
    21e5:	48 01 c5             	add    %rax,%rbp
    21e8:	48 29 c3             	sub    %rax,%rbx
    21eb:	0f 84 2b 03 00 00    	je     251c <submitr+0x70f>
    21f1:	48 89 da             	mov    %rbx,%rdx
    21f4:	48 89 ee             	mov    %rbp,%rsi
    21f7:	44 89 e7             	mov    %r12d,%edi
    21fa:	e8 71 ee ff ff       	callq  1070 <write@plt>
    21ff:	48 85 c0             	test   %rax,%rax
    2202:	7f e1                	jg     21e5 <submitr+0x3d8>
    2204:	e8 37 ee ff ff       	callq  1040 <__errno_location@plt>
    2209:	83 38 04             	cmpl   $0x4,(%rax)
    220c:	0f 85 a0 01 00 00    	jne    23b2 <submitr+0x5a5>
    2212:	4c 89 e8             	mov    %r13,%rax
    2215:	eb ce                	jmp    21e5 <submitr+0x3d8>
    2217:	48 b8 45 72 72 6f 72 	movabs $0x43203a726f727245,%rax
    221e:	3a 20 43 
    2221:	48 ba 6c 69 65 6e 74 	movabs $0x6e7520746e65696c,%rdx
    2228:	20 75 6e 
    222b:	49 89 07             	mov    %rax,(%r15)
    222e:	49 89 57 08          	mov    %rdx,0x8(%r15)
    2232:	48 b8 61 62 6c 65 20 	movabs $0x206f7420656c6261,%rax
    2239:	74 6f 20 
    223c:	48 ba 72 65 61 64 20 	movabs $0x7269662064616572,%rdx
    2243:	66 69 72 
    2246:	49 89 47 10          	mov    %rax,0x10(%r15)
    224a:	49 89 57 18          	mov    %rdx,0x18(%r15)
    224e:	48 b8 73 74 20 68 65 	movabs $0x6564616568207473,%rax
    2255:	61 64 65 
    2258:	48 ba 72 20 66 72 6f 	movabs $0x73206d6f72662072,%rdx
    225f:	6d 20 73 
    2262:	49 89 47 20          	mov    %rax,0x20(%r15)
    2266:	49 89 57 28          	mov    %rdx,0x28(%r15)
    226a:	41 c7 47 30 65 72 76 	movl   $0x65767265,0x30(%r15)
    2271:	65 
    2272:	66 41 c7 47 34 72 00 	movw   $0x72,0x34(%r15)
    2279:	44 89 e7             	mov    %r12d,%edi
    227c:	e8 1f ee ff ff       	callq  10a0 <close@plt>
    2281:	b8 ff ff ff ff       	mov    $0xffffffff,%eax
    2286:	e9 8b 00 00 00       	jmpq   2316 <submitr+0x509>
    228b:	4c 8d 8c 24 60 80 00 	lea    0x8060(%rsp),%r9
    2292:	00 
    2293:	48 8d 0d 5e 11 00 00 	lea    0x115e(%rip),%rcx        # 33f8 <array.3514+0x208>
    229a:	48 c7 c2 ff ff ff ff 	mov    $0xffffffffffffffff,%rdx
    22a1:	be 01 00 00 00       	mov    $0x1,%esi
    22a6:	4c 89 ff             	mov    %r15,%rdi
    22a9:	b8 00 00 00 00       	mov    $0x0,%eax
    22ae:	e8 ed ee ff ff       	callq  11a0 <__sprintf_chk@plt>
    22b3:	44 89 e7             	mov    %r12d,%edi
    22b6:	e8 e5 ed ff ff       	callq  10a0 <close@plt>
    22bb:	b8 ff ff ff ff       	mov    $0xffffffff,%eax
    22c0:	eb 54                	jmp    2316 <submitr+0x509>
    22c2:	48 8d b4 24 60 20 00 	lea    0x2060(%rsp),%rsi
    22c9:	00 
    22ca:	48 8d 7c 24 50       	lea    0x50(%rsp),%rdi
    22cf:	ba 00 20 00 00       	mov    $0x2000,%edx
    22d4:	e8 71 fa ff ff       	callq  1d4a <rio_readlineb>
    22d9:	48 85 c0             	test   %rax,%rax
    22dc:	7e 61                	jle    233f <submitr+0x532>
    22de:	48 8d b4 24 60 20 00 	lea    0x2060(%rsp),%rsi
    22e5:	00 
    22e6:	4c 89 ff             	mov    %r15,%rdi
    22e9:	e8 62 ed ff ff       	callq  1050 <strcpy@plt>
    22ee:	44 89 e7             	mov    %r12d,%edi
    22f1:	e8 aa ed ff ff       	callq  10a0 <close@plt>
    22f6:	b9 03 00 00 00       	mov    $0x3,%ecx
    22fb:	48 8d 3d c1 11 00 00 	lea    0x11c1(%rip),%rdi        # 34c3 <array.3514+0x2d3>
    2302:	4c 89 fe             	mov    %r15,%rsi
    2305:	f3 a6                	repz cmpsb %es:(%rdi),%ds:(%rsi)
    2307:	0f 97 c0             	seta   %al
    230a:	1c 00                	sbb    $0x0,%al
    230c:	84 c0                	test   %al,%al
    230e:	0f 95 c0             	setne  %al
    2311:	0f b6 c0             	movzbl %al,%eax
    2314:	f7 d8                	neg    %eax
    2316:	48 8b 94 24 68 a0 00 	mov    0xa068(%rsp),%rdx
    231d:	00 
    231e:	64 48 33 14 25 28 00 	xor    %fs:0x28,%rdx
    2325:	00 00 
    2327:	0f 85 12 03 00 00    	jne    263f <submitr+0x832>
    232d:	48 81 c4 78 a0 00 00 	add    $0xa078,%rsp
    2334:	5b                   	pop    %rbx
    2335:	5d                   	pop    %rbp
    2336:	41 5c                	pop    %r12
    2338:	41 5d                	pop    %r13
    233a:	41 5e                	pop    %r14
    233c:	41 5f                	pop    %r15
    233e:	c3                   	retq   
    233f:	48 b8 45 72 72 6f 72 	movabs $0x43203a726f727245,%rax
    2346:	3a 20 43 
    2349:	48 ba 6c 69 65 6e 74 	movabs $0x6e7520746e65696c,%rdx
    2350:	20 75 6e 
    2353:	49 89 07             	mov    %rax,(%r15)
    2356:	49 89 57 08          	mov    %rdx,0x8(%r15)
    235a:	48 b8 61 62 6c 65 20 	movabs $0x206f7420656c6261,%rax
    2361:	74 6f 20 
    2364:	48 ba 72 65 61 64 20 	movabs $0x6174732064616572,%rdx
    236b:	73 74 61 
    236e:	49 89 47 10          	mov    %rax,0x10(%r15)
    2372:	49 89 57 18          	mov    %rdx,0x18(%r15)
    2376:	48 b8 74 75 73 20 6d 	movabs $0x7373656d20737574,%rax
    237d:	65 73 73 
    2380:	48 ba 61 67 65 20 66 	movabs $0x6d6f726620656761,%rdx
    2387:	72 6f 6d 
    238a:	49 89 47 20          	mov    %rax,0x20(%r15)
    238e:	49 89 57 28          	mov    %rdx,0x28(%r15)
    2392:	48 b8 20 73 65 72 76 	movabs $0x72657672657320,%rax
    2399:	65 72 00 
    239c:	49 89 47 30          	mov    %rax,0x30(%r15)
    23a0:	44 89 e7             	mov    %r12d,%edi
    23a3:	e8 f8 ec ff ff       	callq  10a0 <close@plt>
    23a8:	b8 ff ff ff ff       	mov    $0xffffffff,%eax
    23ad:	e9 64 ff ff ff       	jmpq   2316 <submitr+0x509>
    23b2:	48 b8 45 72 72 6f 72 	movabs $0x43203a726f727245,%rax
    23b9:	3a 20 43 
    23bc:	48 ba 6c 69 65 6e 74 	movabs $0x6e7520746e65696c,%rdx
    23c3:	20 75 6e 
    23c6:	49 89 07             	mov    %rax,(%r15)
    23c9:	49 89 57 08          	mov    %rdx,0x8(%r15)
    23cd:	48 b8 61 62 6c 65 20 	movabs $0x206f7420656c6261,%rax
    23d4:	74 6f 20 
    23d7:	48 ba 77 72 69 74 65 	movabs $0x6f74206574697277,%rdx
    23de:	20 74 6f 
    23e1:	49 89 47 10          	mov    %rax,0x10(%r15)
    23e5:	49 89 57 18          	mov    %rdx,0x18(%r15)
    23e9:	48 b8 20 74 68 65 20 	movabs $0x7265732065687420,%rax
    23f0:	73 65 72 
    23f3:	49 89 47 20          	mov    %rax,0x20(%r15)
    23f7:	41 c7 47 28 76 65 72 	movl   $0x726576,0x28(%r15)
    23fe:	00 
    23ff:	44 89 e7             	mov    %r12d,%edi
    2402:	e8 99 ec ff ff       	callq  10a0 <close@plt>
    2407:	b8 ff ff ff ff       	mov    $0xffffffff,%eax
    240c:	e9 05 ff ff ff       	jmpq   2316 <submitr+0x509>
    2411:	48 b8 45 72 72 6f 72 	movabs $0x52203a726f727245,%rax
    2418:	3a 20 52 
    241b:	48 ba 65 73 75 6c 74 	movabs $0x747320746c757365,%rdx
    2422:	20 73 74 
    2425:	49 89 07             	mov    %rax,(%r15)
    2428:	49 89 57 08          	mov    %rdx,0x8(%r15)
    242c:	48 b8 72 69 6e 67 20 	movabs $0x6e6f6320676e6972,%rax
    2433:	63 6f 6e 
    2436:	48 ba 74 61 69 6e 73 	movabs $0x6e6120736e696174,%rdx
    243d:	20 61 6e 
    2440:	49 89 47 10          	mov    %rax,0x10(%r15)
    2444:	49 89 57 18          	mov    %rdx,0x18(%r15)
    2448:	48 b8 20 69 6c 6c 65 	movabs $0x6c6167656c6c6920,%rax
    244f:	67 61 6c 
    2452:	48 ba 20 6f 72 20 75 	movabs $0x72706e7520726f20,%rdx
    2459:	6e 70 72 
    245c:	49 89 47 20          	mov    %rax,0x20(%r15)
    2460:	49 89 57 28          	mov    %rdx,0x28(%r15)
    2464:	48 b8 69 6e 74 61 62 	movabs $0x20656c6261746e69,%rax
    246b:	6c 65 20 
    246e:	48 ba 63 68 61 72 61 	movabs $0x6574636172616863,%rdx
    2475:	63 74 65 
    2478:	49 89 47 30          	mov    %rax,0x30(%r15)
    247c:	49 89 57 38          	mov    %rdx,0x38(%r15)
    2480:	66 41 c7 47 40 72 2e 	movw   $0x2e72,0x40(%r15)
    2487:	41 c6 47 42 00       	movb   $0x0,0x42(%r15)
    248c:	44 89 e7             	mov    %r12d,%edi
    248f:	e8 0c ec ff ff       	callq  10a0 <close@plt>
    2494:	b8 ff ff ff ff       	mov    $0xffffffff,%eax
    2499:	e9 78 fe ff ff       	jmpq   2316 <submitr+0x509>
    249e:	48 8d 9c 24 60 20 00 	lea    0x2060(%rsp),%rbx
    24a5:	00 
    24a6:	48 83 ec 08          	sub    $0x8,%rsp
    24aa:	48 8d 84 24 68 40 00 	lea    0x4068(%rsp),%rax
    24b1:	00 
    24b2:	50                   	push   %rax
    24b3:	ff 74 24 28          	pushq  0x28(%rsp)
    24b7:	ff 74 24 38          	pushq  0x38(%rsp)
    24bb:	4c 8b 4c 24 30       	mov    0x30(%rsp),%r9
    24c0:	4c 8b 44 24 28       	mov    0x28(%rsp),%r8
    24c5:	48 8d 0d 5c 0f 00 00 	lea    0xf5c(%rip),%rcx        # 3428 <array.3514+0x238>
    24cc:	ba 00 20 00 00       	mov    $0x2000,%edx
    24d1:	be 01 00 00 00       	mov    $0x1,%esi
    24d6:	48 89 df             	mov    %rbx,%rdi
    24d9:	b8 00 00 00 00       	mov    $0x0,%eax
    24de:	e8 bd ec ff ff       	callq  11a0 <__sprintf_chk@plt>
    24e3:	48 c7 c1 ff ff ff ff 	mov    $0xffffffffffffffff,%rcx
    24ea:	b8 00 00 00 00       	mov    $0x0,%eax
    24ef:	48 89 df             	mov    %rbx,%rdi
    24f2:	f2 ae                	repnz scas %es:(%rdi),%al
    24f4:	48 89 ca             	mov    %rcx,%rdx
    24f7:	48 f7 d2             	not    %rdx
    24fa:	48 89 d1             	mov    %rdx,%rcx
    24fd:	48 83 c4 20          	add    $0x20,%rsp
    2501:	48 8d ac 24 60 20 00 	lea    0x2060(%rsp),%rbp
    2508:	00 
    2509:	41 bd 00 00 00 00    	mov    $0x0,%r13d
    250f:	48 83 e9 01          	sub    $0x1,%rcx
    2513:	48 89 cb             	mov    %rcx,%rbx
    2516:	0f 85 d5 fc ff ff    	jne    21f1 <submitr+0x3e4>
    251c:	44 89 64 24 50       	mov    %r12d,0x50(%rsp)
    2521:	c7 44 24 54 00 00 00 	movl   $0x0,0x54(%rsp)
    2528:	00 
    2529:	48 8d 7c 24 50       	lea    0x50(%rsp),%rdi
    252e:	48 8d 47 10          	lea    0x10(%rdi),%rax
    2532:	48 89 44 24 58       	mov    %rax,0x58(%rsp)
    2537:	48 8d b4 24 60 20 00 	lea    0x2060(%rsp),%rsi
    253e:	00 
    253f:	ba 00 20 00 00       	mov    $0x2000,%edx
    2544:	e8 01 f8 ff ff       	callq  1d4a <rio_readlineb>
    2549:	48 85 c0             	test   %rax,%rax
    254c:	0f 8e c5 fc ff ff    	jle    2217 <submitr+0x40a>
    2552:	48 8d 4c 24 3c       	lea    0x3c(%rsp),%rcx
    2557:	48 8d 94 24 60 60 00 	lea    0x6060(%rsp),%rdx
    255e:	00 
    255f:	48 8d bc 24 60 20 00 	lea    0x2060(%rsp),%rdi
    2566:	00 
    2567:	4c 8d 84 24 60 80 00 	lea    0x8060(%rsp),%r8
    256e:	00 
    256f:	48 8d 35 39 0f 00 00 	lea    0xf39(%rip),%rsi        # 34af <array.3514+0x2bf>
    2576:	b8 00 00 00 00       	mov    $0x0,%eax
    257b:	e8 a0 eb ff ff       	callq  1120 <__isoc99_sscanf@plt>
    2580:	44 8b 44 24 3c       	mov    0x3c(%rsp),%r8d
    2585:	41 81 f8 c8 00 00 00 	cmp    $0xc8,%r8d
    258c:	0f 85 f9 fc ff ff    	jne    228b <submitr+0x47e>
    2592:	48 8d 9c 24 60 20 00 	lea    0x2060(%rsp),%rbx
    2599:	00 
    259a:	48 8d 2d 1f 0f 00 00 	lea    0xf1f(%rip),%rbp        # 34c0 <array.3514+0x2d0>
    25a1:	4c 8d 6c 24 50       	lea    0x50(%rsp),%r13
    25a6:	b9 03 00 00 00       	mov    $0x3,%ecx
    25ab:	48 89 de             	mov    %rbx,%rsi
    25ae:	48 89 ef             	mov    %rbp,%rdi
    25b1:	f3 a6                	repz cmpsb %es:(%rdi),%ds:(%rsi)
    25b3:	0f 97 c0             	seta   %al
    25b6:	1c 00                	sbb    $0x0,%al
    25b8:	84 c0                	test   %al,%al
    25ba:	0f 84 02 fd ff ff    	je     22c2 <submitr+0x4b5>
    25c0:	ba 00 20 00 00       	mov    $0x2000,%edx
    25c5:	48 89 de             	mov    %rbx,%rsi
    25c8:	4c 89 ef             	mov    %r13,%rdi
    25cb:	e8 7a f7 ff ff       	callq  1d4a <rio_readlineb>
    25d0:	48 85 c0             	test   %rax,%rax
    25d3:	7f d1                	jg     25a6 <submitr+0x799>
    25d5:	48 b8 45 72 72 6f 72 	movabs $0x43203a726f727245,%rax
    25dc:	3a 20 43 
    25df:	48 ba 6c 69 65 6e 74 	movabs $0x6e7520746e65696c,%rdx
    25e6:	20 75 6e 
    25e9:	49 89 07             	mov    %rax,(%r15)
    25ec:	49 89 57 08          	mov    %rdx,0x8(%r15)
    25f0:	48 b8 61 62 6c 65 20 	movabs $0x206f7420656c6261,%rax
    25f7:	74 6f 20 
    25fa:	48 ba 72 65 61 64 20 	movabs $0x6165682064616572,%rdx
    2601:	68 65 61 
    2604:	49 89 47 10          	mov    %rax,0x10(%r15)
    2608:	49 89 57 18          	mov    %rdx,0x18(%r15)
    260c:	48 b8 64 65 72 73 20 	movabs $0x6f72662073726564,%rax
    2613:	66 72 6f 
    2616:	48 ba 6d 20 73 65 72 	movabs $0x726576726573206d,%rdx
    261d:	76 65 72 
    2620:	49 89 47 20          	mov    %rax,0x20(%r15)
    2624:	49 89 57 28          	mov    %rdx,0x28(%r15)
    2628:	41 c6 47 30 00       	movb   $0x0,0x30(%r15)
    262d:	44 89 e7             	mov    %r12d,%edi
    2630:	e8 6b ea ff ff       	callq  10a0 <close@plt>
    2635:	b8 ff ff ff ff       	mov    $0xffffffff,%eax
    263a:	e9 d7 fc ff ff       	jmpq   2316 <submitr+0x509>
    263f:	e8 3c ea ff ff       	callq  1080 <__stack_chk_fail@plt>

0000000000002644 <init_timeout>:
    2644:	85 ff                	test   %edi,%edi
    2646:	74 25                	je     266d <init_timeout+0x29>
    2648:	53                   	push   %rbx
    2649:	89 fb                	mov    %edi,%ebx
    264b:	48 8d 35 c8 f6 ff ff 	lea    -0x938(%rip),%rsi        # 1d1a <sigalrm_handler>
    2652:	bf 0e 00 00 00       	mov    $0xe,%edi
    2657:	e8 74 ea ff ff       	callq  10d0 <signal@plt>
    265c:	85 db                	test   %ebx,%ebx
    265e:	bf 00 00 00 00       	mov    $0x0,%edi
    2663:	0f 49 fb             	cmovns %ebx,%edi
    2666:	e8 25 ea ff ff       	callq  1090 <alarm@plt>
    266b:	5b                   	pop    %rbx
    266c:	c3                   	retq   
    266d:	c3                   	retq   

000000000000266e <init_driver>:
    266e:	41 54                	push   %r12
    2670:	55                   	push   %rbp
    2671:	53                   	push   %rbx
    2672:	48 83 ec 20          	sub    $0x20,%rsp
    2676:	49 89 fc             	mov    %rdi,%r12
    2679:	64 48 8b 04 25 28 00 	mov    %fs:0x28,%rax
    2680:	00 00 
    2682:	48 89 44 24 18       	mov    %rax,0x18(%rsp)
    2687:	31 c0                	xor    %eax,%eax
    2689:	be 01 00 00 00       	mov    $0x1,%esi
    268e:	bf 0d 00 00 00       	mov    $0xd,%edi
    2693:	e8 38 ea ff ff       	callq  10d0 <signal@plt>
    2698:	be 01 00 00 00       	mov    $0x1,%esi
    269d:	bf 1d 00 00 00       	mov    $0x1d,%edi
    26a2:	e8 29 ea ff ff       	callq  10d0 <signal@plt>
    26a7:	be 01 00 00 00       	mov    $0x1,%esi
    26ac:	bf 1d 00 00 00       	mov    $0x1d,%edi
    26b1:	e8 1a ea ff ff       	callq  10d0 <signal@plt>
    26b6:	ba 00 00 00 00       	mov    $0x0,%edx
    26bb:	be 01 00 00 00       	mov    $0x1,%esi
    26c0:	bf 02 00 00 00       	mov    $0x2,%edi
    26c5:	e8 e6 ea ff ff       	callq  11b0 <socket@plt>
    26ca:	85 c0                	test   %eax,%eax
    26cc:	0f 88 a3 00 00 00    	js     2775 <init_driver+0x107>
    26d2:	89 c3                	mov    %eax,%ebx
    26d4:	48 8d 3d eb 0d 00 00 	lea    0xdeb(%rip),%rdi        # 34c6 <array.3514+0x2d6>
    26db:	e8 00 ea ff ff       	callq  10e0 <gethostbyname@plt>
    26e0:	48 85 c0             	test   %rax,%rax
    26e3:	0f 84 df 00 00 00    	je     27c8 <init_driver+0x15a>
    26e9:	48 89 e5             	mov    %rsp,%rbp
    26ec:	48 c7 44 24 02 00 00 	movq   $0x0,0x2(%rsp)
    26f3:	00 00 
    26f5:	c7 45 0a 00 00 00 00 	movl   $0x0,0xa(%rbp)
    26fc:	66 c7 45 0e 00 00    	movw   $0x0,0xe(%rbp)
    2702:	66 c7 04 24 02 00    	movw   $0x2,(%rsp)
    2708:	48 63 50 14          	movslq 0x14(%rax),%rdx
    270c:	48 8b 40 18          	mov    0x18(%rax),%rax
    2710:	48 8d 7d 04          	lea    0x4(%rbp),%rdi
    2714:	b9 0c 00 00 00       	mov    $0xc,%ecx
    2719:	48 8b 30             	mov    (%rax),%rsi
    271c:	e8 cf e9 ff ff       	callq  10f0 <__memmove_chk@plt>
    2721:	66 c7 44 24 02 3b 6e 	movw   $0x6e3b,0x2(%rsp)
    2728:	ba 10 00 00 00       	mov    $0x10,%edx
    272d:	48 89 ee             	mov    %rbp,%rsi
    2730:	89 df                	mov    %ebx,%edi
    2732:	e8 29 ea ff ff       	callq  1160 <connect@plt>
    2737:	85 c0                	test   %eax,%eax
    2739:	0f 88 fb 00 00 00    	js     283a <init_driver+0x1cc>
    273f:	89 df                	mov    %ebx,%edi
    2741:	e8 5a e9 ff ff       	callq  10a0 <close@plt>
    2746:	66 41 c7 04 24 4f 4b 	movw   $0x4b4f,(%r12)
    274d:	41 c6 44 24 02 00    	movb   $0x0,0x2(%r12)
    2753:	b8 00 00 00 00       	mov    $0x0,%eax
    2758:	48 8b 4c 24 18       	mov    0x18(%rsp),%rcx
    275d:	64 48 33 0c 25 28 00 	xor    %fs:0x28,%rcx
    2764:	00 00 
    2766:	0f 85 06 01 00 00    	jne    2872 <init_driver+0x204>
    276c:	48 83 c4 20          	add    $0x20,%rsp
    2770:	5b                   	pop    %rbx
    2771:	5d                   	pop    %rbp
    2772:	41 5c                	pop    %r12
    2774:	c3                   	retq   
    2775:	48 b8 45 72 72 6f 72 	movabs $0x43203a726f727245,%rax
    277c:	3a 20 43 
    277f:	48 ba 6c 69 65 6e 74 	movabs $0x6e7520746e65696c,%rdx
    2786:	20 75 6e 
    2789:	49 89 04 24          	mov    %rax,(%r12)
    278d:	49 89 54 24 08       	mov    %rdx,0x8(%r12)
    2792:	48 b8 61 62 6c 65 20 	movabs $0x206f7420656c6261,%rax
    2799:	74 6f 20 
    279c:	48 ba 63 72 65 61 74 	movabs $0x7320657461657263,%rdx
    27a3:	65 20 73 
    27a6:	49 89 44 24 10       	mov    %rax,0x10(%r12)
    27ab:	49 89 54 24 18       	mov    %rdx,0x18(%r12)
    27b0:	41 c7 44 24 20 6f 63 	movl   $0x656b636f,0x20(%r12)
    27b7:	6b 65 
    27b9:	66 41 c7 44 24 24 74 	movw   $0x74,0x24(%r12)
    27c0:	00 
    27c1:	b8 ff ff ff ff       	mov    $0xffffffff,%eax
    27c6:	eb 90                	jmp    2758 <init_driver+0xea>
    27c8:	48 b8 45 72 72 6f 72 	movabs $0x44203a726f727245,%rax
    27cf:	3a 20 44 
    27d2:	48 ba 4e 53 20 69 73 	movabs $0x6e7520736920534e,%rdx
    27d9:	20 75 6e 
    27dc:	49 89 04 24          	mov    %rax,(%r12)
    27e0:	49 89 54 24 08       	mov    %rdx,0x8(%r12)
    27e5:	48 b8 61 62 6c 65 20 	movabs $0x206f7420656c6261,%rax
    27ec:	74 6f 20 
    27ef:	48 ba 72 65 73 6f 6c 	movabs $0x2065766c6f736572,%rdx
    27f6:	76 65 20 
    27f9:	49 89 44 24 10       	mov    %rax,0x10(%r12)
    27fe:	49 89 54 24 18       	mov    %rdx,0x18(%r12)
    2803:	48 b8 73 65 72 76 65 	movabs $0x6120726576726573,%rax
    280a:	72 20 61 
    280d:	49 89 44 24 20       	mov    %rax,0x20(%r12)
    2812:	41 c7 44 24 28 64 64 	movl   $0x65726464,0x28(%r12)
    2819:	72 65 
    281b:	66 41 c7 44 24 2c 73 	movw   $0x7373,0x2c(%r12)
    2822:	73 
    2823:	41 c6 44 24 2e 00    	movb   $0x0,0x2e(%r12)
    2829:	89 df                	mov    %ebx,%edi
    282b:	e8 70 e8 ff ff       	callq  10a0 <close@plt>
    2830:	b8 ff ff ff ff       	mov    $0xffffffff,%eax
    2835:	e9 1e ff ff ff       	jmpq   2758 <init_driver+0xea>
    283a:	4c 8d 05 85 0c 00 00 	lea    0xc85(%rip),%r8        # 34c6 <array.3514+0x2d6>
    2841:	48 8d 0d 38 0c 00 00 	lea    0xc38(%rip),%rcx        # 3480 <array.3514+0x290>
    2848:	48 c7 c2 ff ff ff ff 	mov    $0xffffffffffffffff,%rdx
    284f:	be 01 00 00 00       	mov    $0x1,%esi
    2854:	4c 89 e7             	mov    %r12,%rdi
    2857:	b8 00 00 00 00       	mov    $0x0,%eax
    285c:	e8 3f e9 ff ff       	callq  11a0 <__sprintf_chk@plt>
    2861:	89 df                	mov    %ebx,%edi
    2863:	e8 38 e8 ff ff       	callq  10a0 <close@plt>
    2868:	b8 ff ff ff ff       	mov    $0xffffffff,%eax
    286d:	e9 e6 fe ff ff       	jmpq   2758 <init_driver+0xea>
    2872:	e8 09 e8 ff ff       	callq  1080 <__stack_chk_fail@plt>

0000000000002877 <driver_post>:
    2877:	53                   	push   %rbx
    2878:	4c 89 c3             	mov    %r8,%rbx
    287b:	85 c9                	test   %ecx,%ecx
    287d:	75 17                	jne    2896 <driver_post+0x1f>
    287f:	48 85 ff             	test   %rdi,%rdi
    2882:	74 05                	je     2889 <driver_post+0x12>
    2884:	80 3f 00             	cmpb   $0x0,(%rdi)
    2887:	75 33                	jne    28bc <driver_post+0x45>
    2889:	66 c7 03 4f 4b       	movw   $0x4b4f,(%rbx)
    288e:	c6 43 02 00          	movb   $0x0,0x2(%rbx)
    2892:	89 c8                	mov    %ecx,%eax
    2894:	5b                   	pop    %rbx
    2895:	c3                   	retq   
    2896:	48 8d 35 41 0c 00 00 	lea    0xc41(%rip),%rsi        # 34de <array.3514+0x2ee>
    289d:	bf 01 00 00 00       	mov    $0x1,%edi
    28a2:	b8 00 00 00 00       	mov    $0x0,%eax
    28a7:	e8 84 e8 ff ff       	callq  1130 <__printf_chk@plt>
    28ac:	66 c7 03 4f 4b       	movw   $0x4b4f,(%rbx)
    28b1:	c6 43 02 00          	movb   $0x0,0x2(%rbx)
    28b5:	b8 00 00 00 00       	mov    $0x0,%eax
    28ba:	eb d8                	jmp    2894 <driver_post+0x1d>
    28bc:	41 50                	push   %r8
    28be:	52                   	push   %rdx
    28bf:	4c 8d 0d 2f 0c 00 00 	lea    0xc2f(%rip),%r9        # 34f5 <array.3514+0x305>
    28c6:	49 89 f0             	mov    %rsi,%r8
    28c9:	48 89 f9             	mov    %rdi,%rcx
    28cc:	48 8d 15 2a 0c 00 00 	lea    0xc2a(%rip),%rdx        # 34fd <array.3514+0x30d>
    28d3:	be 6e 3b 00 00       	mov    $0x3b6e,%esi
    28d8:	48 8d 3d e7 0b 00 00 	lea    0xbe7(%rip),%rdi        # 34c6 <array.3514+0x2d6>
    28df:	e8 29 f5 ff ff       	callq  1e0d <submitr>
    28e4:	48 83 c4 10          	add    $0x10,%rsp
    28e8:	eb aa                	jmp    2894 <driver_post+0x1d>
    28ea:	66 0f 1f 44 00 00    	nopw   0x0(%rax,%rax,1)

00000000000028f0 <__libc_csu_init>:
    28f0:	41 57                	push   %r15
    28f2:	49 89 d7             	mov    %rdx,%r15
    28f5:	41 56                	push   %r14
    28f7:	49 89 f6             	mov    %rsi,%r14
    28fa:	41 55                	push   %r13
    28fc:	41 89 fd             	mov    %edi,%r13d
    28ff:	41 54                	push   %r12
    2901:	4c 8d 25 f0 23 00 00 	lea    0x23f0(%rip),%r12        # 4cf8 <__frame_dummy_init_array_entry>
    2908:	55                   	push   %rbp
    2909:	48 8d 2d f0 23 00 00 	lea    0x23f0(%rip),%rbp        # 4d00 <__init_array_end>
    2910:	53                   	push   %rbx
    2911:	4c 29 e5             	sub    %r12,%rbp
    2914:	48 83 ec 08          	sub    $0x8,%rsp
    2918:	e8 e3 e6 ff ff       	callq  1000 <_init>
    291d:	48 c1 fd 03          	sar    $0x3,%rbp
    2921:	74 1b                	je     293e <__libc_csu_init+0x4e>
    2923:	31 db                	xor    %ebx,%ebx
    2925:	0f 1f 00             	nopl   (%rax)
    2928:	4c 89 fa             	mov    %r15,%rdx
    292b:	4c 89 f6             	mov    %r14,%rsi
    292e:	44 89 ef             	mov    %r13d,%edi
    2931:	41 ff 14 dc          	callq  *(%r12,%rbx,8)
    2935:	48 83 c3 01          	add    $0x1,%rbx
    2939:	48 39 dd             	cmp    %rbx,%rbp
    293c:	75 ea                	jne    2928 <__libc_csu_init+0x38>
    293e:	48 83 c4 08          	add    $0x8,%rsp
    2942:	5b                   	pop    %rbx
    2943:	5d                   	pop    %rbp
    2944:	41 5c                	pop    %r12
    2946:	41 5d                	pop    %r13
    2948:	41 5e                	pop    %r14
    294a:	41 5f                	pop    %r15
    294c:	c3                   	retq   
    294d:	0f 1f 00             	nopl   (%rax)

0000000000002950 <__libc_csu_fini>:
    2950:	c3                   	retq   

Disassembly of section .fini:

0000000000002954 <_fini>:
    2954:	48 83 ec 08          	sub    $0x8,%rsp
    2958:	48 83 c4 08          	add    $0x8,%rsp
    295c:	c3                   	retq   
