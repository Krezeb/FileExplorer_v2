# FileExplorer_v2

<p>Attempt to refactor my previous app "ConsoleFileExplorer" with a data layer and easier to follow logic and naming.
Code is now easier to follow and the naming convention used is more consistant.</p>

Functions availible:

<h2>Explorer</h2>
<ul>
<li><p><strong>ENTER</strong> - Will cause you to enter the selected directory.</p></li>
<li><p><strong>BACKSPACE</strong> - Will return you to the current directorys Parent.</p></li>
<li><p><strong>ARROW UP</strong> - Will move selection box up</p></li>
<li><p><strong>ARROW DOWN</strong> - Will move selection box down</p></li>
</ul>
<p>Starting Directory will be where the .exe file is located.</p>


<h2>Create new Text File-</h2>
<ul>
<li><p><strong>C</strong> - Will create a new text file in the current directory and allow you to to write lines into it.</p></li>
</ul>
<p>Pressing ENTER while a line is empty will save all written lines to file and return you to the Explorer interface.</p>

<h2>Open File-</h2>
<ul>
<li><p><strong>SPACE</strong> - Will open the currently selected file and print all lines inside to the console. Pressing any key after loading will return you to the Explorer.</p></li>
</ul>

<h2>Delete File-</h2>
<ul>
<li><p><strong>D</strong> - Will Delete currently selected file. Will ask for confirmation before deletion. This Method bypasses the recycle bin. BE CAREFUL. Will not delete directories.</p></li>
</ul>
