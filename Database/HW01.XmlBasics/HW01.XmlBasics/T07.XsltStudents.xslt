<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output indent="no" method="html"/>
  <xsl:template match="/">
    <html>
      <!-- [CDATA[ Run XML file T02.Students.xml ]] -->
      <body>
        <h1>Students</h1>
        <xsl:for-each select="/students/student">
          <ol>
            <li>
              name: <xsl:value-of select="name"/>
            </li>
            <li>
              sex: <xsl:value-of select="man"/>
            </li>
            <li>
              birthdate: <xsl:value-of select="birthdate"/>
            </li>
            <li>
              phone: <xsl:value-of select="phone"/>
            </li>
            <li>
              email: <xsl:value-of select="email"/>
            </li>
            <li>
              course: <xsl:value-of select="course"/>
            </li>
            <li>
              specialty: <xsl:value-of select="specialty"/>
            </li>
            <li>
              facultynumber: <xsl:value-of select="facultynumber"/>
            </li>
            <xsl:for-each select="exams/exam">
              <li>
                <ul>
                  <li>
                    name: <xsl:value-of select="name"/>
                  </li>
                  <li>
                    <xsl:for-each select="tutor">
                      tutor:
                      <ul>
                        <li>
                          name: <xsl:value-of select="name"/>
                        </li>
                        <li>
                          endorsements: <xsl:value-of select="endorsements"/>
                        </li>
                      </ul>
                    </xsl:for-each>
                  </li>
                  <li>
                    score: <xsl:value-of select="score"/>
                  </li>
                  <li>
                    enrollment
                    <ul>
                      <li>
                        date: <xsl:value-of select="enrollment/date"/>
                      </li>
                      <li>
                        examscore: <xsl:value-of select="enrollment/examscore"/>
                      </li>
                    </ul>
                  </li>
                </ul>
              </li>
            </xsl:for-each>
          </ol>
        </xsl:for-each>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>