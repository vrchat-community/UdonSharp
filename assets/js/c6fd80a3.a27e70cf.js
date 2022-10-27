"use strict";(self.webpackChunkclient_sim=self.webpackChunkclient_sim||[]).push([[7578],{3905:function(e,t,n){n.d(t,{Zo:function(){return c},kt:function(){return h}});var r=n(7294);function o(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}function i(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var r=Object.getOwnPropertySymbols(e);t&&(r=r.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,r)}return n}function a(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?i(Object(n),!0).forEach((function(t){o(e,t,n[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):i(Object(n)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))}))}return e}function s(e,t){if(null==e)return{};var n,r,o=function(e,t){if(null==e)return{};var n,r,o={},i=Object.keys(e);for(r=0;r<i.length;r++)n=i[r],t.indexOf(n)>=0||(o[n]=e[n]);return o}(e,t);if(Object.getOwnPropertySymbols){var i=Object.getOwnPropertySymbols(e);for(r=0;r<i.length;r++)n=i[r],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(o[n]=e[n])}return o}var l=r.createContext({}),p=function(e){var t=r.useContext(l),n=t;return e&&(n="function"==typeof e?e(t):a(a({},t),e)),n},c=function(e){var t=p(e.components);return r.createElement(l.Provider,{value:t},e.children)},u={inlineCode:"code",wrapper:function(e){var t=e.children;return r.createElement(r.Fragment,{},t)}},m=r.forwardRef((function(e,t){var n=e.components,o=e.mdxType,i=e.originalType,l=e.parentName,c=s(e,["components","mdxType","originalType","parentName"]),m=p(n),h=o,d=m["".concat(l,".").concat(h)]||m[h]||u[h]||i;return n?r.createElement(d,a(a({ref:t},c),{},{components:n})):r.createElement(d,a({ref:t},c))}));function h(e,t){var n=arguments,o=t&&t.mdxType;if("string"==typeof e||o){var i=n.length,a=new Array(i);a[0]=m;var s={};for(var l in t)hasOwnProperty.call(t,l)&&(s[l]=t[l]);s.originalType=e,s.mdxType="string"==typeof e?e:o,a[1]=s;for(var p=2;p<i;p++)a[p]=n[p];return r.createElement.apply(null,a)}return r.createElement.apply(null,n)}m.displayName="MDXCreateElement"},1108:function(e,t,n){n.r(t),n.d(t,{assets:function(){return c},contentTitle:function(){return l},default:function(){return h},frontMatter:function(){return s},metadata:function(){return p},toc:function(){return u}});var r=n(7462),o=n(3366),i=(n(7294),n(3905)),a=["components"],s={id:"migration",title:"Migration",hide_title:!0},l="Migration",p={unversionedId:"migration",id:"migration",title:"Migration",description:"UdonSharp 0.x (the .unitypackage version) is deprecated and no longer supported. This new version is easy to get through the Creator Companion, which will help you keep it up-to-date as well.",source:"@site/docs/Migration.md",sourceDirName:".",slug:"/migration",permalink:"/migration",editUrl:"https://github.com/vrchat-community/UdonSharp/edit/master/Docs/Source/Migration.md",tags:[],version:"current",frontMatter:{id:"migration",title:"Migration",hide_title:!0}},c={},u=[{value:"Known Issues",id:"known-issues",level:2},{value:"Nested Prefabs",id:"nested-prefabs",level:3},{value:"Does Not Belong to U# Assembly",id:"does-not-belong-to-u-assembly",level:3},{value:"Newtonsoft.Json.Dll",id:"newtonsoftjsondll",level:3}],m={toc:u};function h(e){var t=e.components,n=(0,o.Z)(e,a);return(0,i.kt)("wrapper",(0,r.Z)({},m,n,{components:t,mdxType:"MDXLayout"}),(0,i.kt)("h1",{id:"migration"},"Migration"),(0,i.kt)("p",null,"UdonSharp 0.x (the .unitypackage version) is deprecated and no longer supported. This new version is easy to get through the ",(0,i.kt)("a",{parentName:"p",href:"https://vcc.docs.vrchat.com"},"Creator Companion"),", which will help you keep it up-to-date as well."),(0,i.kt)("p",null,(0,i.kt)("a",{parentName:"p",href:"https://vcc.docs.vrchat.com/vpm/migrating"},"Migrating Projects using the Creator Companion"),"."),(0,i.kt)("h2",{id:"known-issues"},"Known Issues"),(0,i.kt)("h3",{id:"nested-prefabs"},"Nested Prefabs"),(0,i.kt)("p",null,(0,i.kt)("strong",{parentName:"p"},"Issue"),": UdonSharp always warned against using nested prefabs, and now they will completely break in some circumstances."),(0,i.kt)("p",null,(0,i.kt)("strong",{parentName:"p"},"Symptoms"),": Errors like ",(0,i.kt)("inlineCode",{parentName:"p"},"Cannot upgrade scene behaviour 'SomethingOrOther' since its prefab must be upgraded")),(0,i.kt)("p",null,(0,i.kt)("strong",{parentName:"p"},"How to Fix"),': Unpack the prefab in your 0.x UdonSharp project first. You can also open the "Udon Sharp" menu item and choose "Force Upgrade".'),(0,i.kt)("h3",{id:"does-not-belong-to-u-assembly"},"Does Not Belong to U# Assembly"),(0,i.kt)("p",null,(0,i.kt)("strong",{parentName:"p"},"Issue"),": Libraries with their own Assembly Definitions need to have an U# assembly definition, too."),(0,i.kt)("p",null,(0,i.kt)("strong",{parentName:"p"},"Symptoms"),": An error like this: ",(0,i.kt)("inlineCode",{parentName:"p"},"[UdonSharp] Script 'Assets/MyScript.cs' does not belong to a U# assembly, have you made a U# assembly definition for the assembly the script is a part of?")),(0,i.kt)("p",null,(0,i.kt)("strong",{parentName:"p"},"How to Fix"),":"),(0,i.kt)("ol",null,(0,i.kt)("li",{parentName:"ol"},"Use the Project window to find the file ending in ",(0,i.kt)("inlineCode",{parentName:"li"},".asmdef")," in the same or a parent directory of the script in question. "),(0,i.kt)("li",{parentName:"ol"},"Right-click in the folder which has this Assembly Definition and choose ",(0,i.kt)("inlineCode",{parentName:"li"},"Create > U# Assembly Definition"),". "),(0,i.kt)("li",{parentName:"ol"},'Select this new U# asmdef, and use the Inspector to set its "Source Assembly" to the other Assembly Definition File. '),(0,i.kt)("li",{parentName:"ol"},"You may need to restart Unity after doing this.")),(0,i.kt)("h3",{id:"newtonsoftjsondll"},"Newtonsoft.Json.Dll"),(0,i.kt)("p",null,(0,i.kt)("strong",{parentName:"p"},"Issue"),": Some packages include their own copy of this JSON library, which the VRCSDK pulls in itself. This results in two copies of the library."),(0,i.kt)("p",null,(0,i.kt)("strong",{parentName:"p"},"Symptoms"),": Errors in your console which mention the above library. It might not be at the front of the sentence, but something like ",(0,i.kt)("inlineCode",{parentName:"p"},"System.TypeInitializationException: the type initializer for blah blah blah...Assets/SketchfabForUnity/Dependencies/Libraries/Newtonsoft.Json.dll")),(0,i.kt)("p",null,(0,i.kt)("strong",{parentName:"p"},"How to Fix"),": Remove any copies of Newtonsoft.Json.dll from your Assets folder, the VRCSDK will provide it for any package that needs it through the Package Manager."))}h.isMDXComponent=!0}}]);