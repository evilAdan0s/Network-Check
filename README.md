# Network-Check
使用C#实现的出网探测工具，可以快速测试当前环境所支持的出网方式

# 编译环境
- MacOS 10.14
- Rider 2020
- .Net Framework 3.5

# 使用方法
```
Network-Check.exe -h <DomainName>
                  -t <IP> <Port>
                  -d <DomainName>
```
- -h 探测HTTP出网，指定域名，例如：`Network-Check.exe -h www.baidu.com`
- -t 探测TCP出网，指定IP和端口，例如：`Network-Check.exe -t 192.168.1.1 4444`
- -d 探测DNS出网，指定域名，如Cobalt Strike的DNS beacon绑定域名，会返回DNS查询出的IP，可以对照是否为Cobalt Strike server地址，例如：`Network-Check.exe -d www.evil.com`

# 演示
环境：Windows 7 Pro x64

HTTP：

![20201210224119BOPKPa](https://adan0s-1256533472.cos.ap-nanjing.myqcloud.com/uPic/20201210224119BOPKPa.png)

TCP，目标机器使用nc监听：

![20201210224443ydKSQQ](https://adan0s-1256533472.cos.ap-nanjing.myqcloud.com/uPic/20201210224443ydKSQQ.png)

DNS：

![20201210224514DDI4RY](https://adan0s-1256533472.cos.ap-nanjing.myqcloud.com/uPic/20201210224514DDI4RY.png)